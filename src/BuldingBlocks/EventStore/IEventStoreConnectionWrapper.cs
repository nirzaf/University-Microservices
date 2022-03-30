using System.Threading.Tasks;
using EventStore.ClientAPI;

namespace BuildingBlocks.EventStore;

public interface IEventStoreConnectionWrapper
{
    Task<IEventStoreConnection> GetConnectionAsync();
}