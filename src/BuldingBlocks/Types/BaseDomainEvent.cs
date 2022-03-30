using System;

namespace BuildingBlocks.Types;

public abstract class BaseDomainEvent<TA, TKey> : IDomainEvent<TKey>
    where TA : IAggregateRoot<TKey>
{
    /// <summary>
    ///     for deserialization
    /// </summary>
    protected BaseDomainEvent()
    {
    }

    /// <summary>
    ///     every subclass should call this one
    ///     TODO: note to future self: I don't like it and neither should you. Find a better way.
    /// </summary>
    /// <param name="aggregateRoot"></param>
    protected BaseDomainEvent(TA aggregateRoot)
    {
        if (aggregateRoot is null)
            throw new ArgumentNullException(nameof(aggregateRoot));

        //  this.AggregateVersion = aggregateRoot.Version;
        AggregateId = aggregateRoot.Id;
        Timestamp = DateTime.UtcNow;
    }

    public long AggregateVersion { get; private set; }
    public TKey AggregateId { get; }
    public DateTime Timestamp { get; }
}