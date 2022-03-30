using System.Threading.Tasks;
using BuildingBlocks.Types;

namespace BuildingBlocks.EventStore;

public interface IEventsService<TA, TKey>
    where TA : class, IAggregateRoot<TKey>
{
    Task SaveAsync(TA aggregateRoot);
    Task<TA> GetByIdAsync(TKey key);
}