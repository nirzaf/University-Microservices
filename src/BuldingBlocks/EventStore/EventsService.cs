using System;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.Types;

namespace BuildingBlocks.EventStore;

public class EventsService<TA, TKey> : IEventsService<TA, TKey> where TA : class, IAggregateRoot<TKey>
{
    private readonly IEventsRepository<TA, TKey> _eventsRepository;

    public EventsService(IEventsRepository<TA, TKey> eventsRepository)
    {
        _eventsRepository = eventsRepository ?? throw new ArgumentNullException(nameof(eventsRepository));
    }

    public async Task SaveAsync(TA aggregateRoot)
    {
        if (null == aggregateRoot)
            throw new ArgumentNullException(nameof(aggregateRoot));

        if (!aggregateRoot.Events.Any())
            return;

        await _eventsRepository.SaveAsync(aggregateRoot);

        aggregateRoot.ClearEvents();
    }

    public Task<TA> GetByIdAsync(TKey key)
    {
        return _eventsRepository.GetByIdAsync(key);
    }
}