using System.Threading.Tasks;

namespace BuildingBlocks.CQRS.Events;

public interface IEventDispatcher
{
    Task PublishAsync<T>(T @event) where T : class, IEvent;
}