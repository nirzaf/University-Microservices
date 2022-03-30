using System.Threading.Tasks;

namespace BuildingBlocks.CQRS.Events;

public interface IEventHandler<in TEvent> where TEvent : IEvent
{
    Task HandleAsync(TEvent @event);
}