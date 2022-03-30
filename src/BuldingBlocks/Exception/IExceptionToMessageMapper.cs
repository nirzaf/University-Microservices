using BuildingBlocks.CQRS.Events;

namespace BuildingBlocks.Exception;

public interface IExceptionToMessageMapper
{
    IRejectedEvent Map(System.Exception exception, object message);
}