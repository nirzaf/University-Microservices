using System.Collections.Generic;
using BuildingBlocks.CQRS.Events;
using BuildingBlocks.Types;

namespace University.Instructors.Application.Services;

public interface IEventMapper
{
    IEvent Map(IDomainEvent @event);
    IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events);
}