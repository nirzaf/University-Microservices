using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildingBlocks.Types;
using EventStore.ClientAPI;

namespace BuildingBlocks.EventStore;

public class EventsRepository<TA, TKey> : IEventsRepository<TA, TKey>
    where TA : class, IAggregateRoot<TKey>
{
    private readonly IEventStoreConnectionWrapper _connectionWrapper;
    private readonly IEventSerializer _eventDeserializer;
    private readonly string _streamBaseName;

    public EventsRepository(IEventStoreConnectionWrapper connectionWrapper, IEventSerializer eventDeserializer)
    {
        _connectionWrapper = connectionWrapper;
        _eventDeserializer = eventDeserializer;

        var aggregateType = typeof(TA);
        _streamBaseName = aggregateType.Name;
    }

    public async Task SaveAsync(TA aggregateRoot)
    {
        if (null == aggregateRoot)
            throw new ArgumentNullException(nameof(aggregateRoot));

        if (!aggregateRoot.Events.Any())
            return;

        var connection = await _connectionWrapper.GetConnectionAsync();

        var streamName = GetStreamName(aggregateRoot.Id);

        var firstEvent = aggregateRoot.Events.First();
        // var version = firstEvent.AggregateVersion - 1;
        var version = -1;


        using var transaction = await connection.StartTransactionAsync(streamName, version);

        try
        {
            foreach (var @event in aggregateRoot.Events)
            {
                // var eventData = Map(@event);
                var eventData = Map(null);
                await transaction.WriteAsync(eventData);
            }

            await transaction.CommitAsync();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<TA> GetByIdAsync(TKey key)
    {
        var connection = await _connectionWrapper.GetConnectionAsync();

        var streamName = GetStreamName(key);

        var events = new List<IDomainEvent<TKey>>();

        StreamEventsSlice currentSlice;
        long nextSliceStart = StreamPosition.Start;
        do
        {
            currentSlice = await connection.ReadStreamEventsForwardAsync(streamName, nextSliceStart, 200, false);

            nextSliceStart = currentSlice.NextEventNumber;

            events.AddRange(currentSlice.Events.Select(Map));
        } while (!currentSlice.IsEndOfStream);

        if (!events.Any())
            return null;

        var result = BaseAggregateRoot<TA, TKey>.Create(events.OrderBy(e => e.AggregateVersion));

        return result;
    }

    private string GetStreamName(TKey aggregateKey)
    {
        var streamName = $"{_streamBaseName}_{aggregateKey}";
        return streamName;
    }

    private IDomainEvent<TKey> Map(ResolvedEvent resolvedEvent)
    {
        var meta = JsonSerializer.Deserialize<EventMeta>(resolvedEvent.Event.Metadata);
        return _eventDeserializer.Deserialize<TKey>(meta.EventType, resolvedEvent.Event.Data);
    }

    private static EventData Map(IDomainEvent<TKey> @event)
    {
        var json = JsonSerializer.Serialize((dynamic) @event);
        var data = Encoding.UTF8.GetBytes(json);

        var eventType = @event.GetType();
        var meta = new EventMeta
        {
            EventType = eventType.AssemblyQualifiedName
        };
        var metaJson = JsonSerializer.Serialize(meta);
        var metadata = Encoding.UTF8.GetBytes(metaJson);

        var eventPayload = new EventData(Guid.NewGuid(), eventType.Name, true, data, metadata);
        return eventPayload;
    }

    internal struct EventMeta
    {
        public string EventType { get; set; }
    }
}