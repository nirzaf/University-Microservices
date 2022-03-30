using System.Collections.Generic;

namespace BuildingBlocks.Types;

public interface IAggregateRoot<out TKey> : IIdentifiable<TKey>
{
    IEnumerable<IDomainEvent> Events { get; }
    void ClearEvents();
}