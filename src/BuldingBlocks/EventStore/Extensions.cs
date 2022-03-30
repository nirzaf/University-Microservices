using System;
using BuildingBlocks.Types;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.EventStore;

public static class Extensions
{
    private const string SectionName = "eventSource";

    public static IServiceCollection AddEventStore(this IServiceCollection services,
        string sectionName = SectionName)
    {
        var eventSourceOptions = services.GetOptions<EventSourceOptions>(sectionName);

        services.AddSingleton<IEventSerializer, JsonEventSerializer>();

        return services.AddSingleton<IEventStoreConnectionWrapper>(ctx =>
        {
            var logger = ctx.GetRequiredService<ILogger<EventStoreConnectionWrapper>>();
            return new EventStoreConnectionWrapper(new Uri(eventSourceOptions.ConnectionString), logger);
        });
    }

    public static IServiceCollection AddEventsRepository<TEntity, TIdentifiable>(this IServiceCollection services)
        where TEntity : class, IAggregateRoot<TIdentifiable>
    {
        services.AddScoped<IEventsService<TEntity, TIdentifiable>, EventsService<TEntity, TIdentifiable>>();

        return services.AddSingleton<IEventsRepository<TEntity, TIdentifiable>>(ctx =>
        {
            var connectionWrapper = ctx.GetRequiredService<IEventStoreConnectionWrapper>();
            var eventDeserializer = ctx.GetRequiredService<IEventSerializer>();
            return new EventsRepository<TEntity, TIdentifiable>(connectionWrapper, eventDeserializer);
        });
    }
}