using BuildingBlocks.CQRS.Events;
using BuildingBlocks.Types;

namespace University.Courses.Application.Services;

public interface IEventMapper
{
    IEvent Map(IDomainEvent @event);
}