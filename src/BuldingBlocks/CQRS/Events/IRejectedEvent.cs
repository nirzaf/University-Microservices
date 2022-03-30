namespace BuildingBlocks.CQRS.Events;

public interface IRejectedEvent : IEvent
{
    string Reason { get; }
}