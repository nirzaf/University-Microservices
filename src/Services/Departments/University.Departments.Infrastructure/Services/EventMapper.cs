using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.CQRS.Events;
using BuildingBlocks.Types;
using University.Departments.Application.Events;
using University.Departments.Application.Services;
using University.Departments.Core.Events;

namespace University.Departments.Infrastructure.Services;

internal sealed class EventMapper : IEventMapper
{
    public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events)
    {
        return events.Select(Map);
    }

    public IEvent Map(IDomainEvent @event)
    {
        return @event switch
        {
            DepartmentCreatedDomainEvent e => new DepartmentCreated(e.Id),
            AdministratorAssignedDomainEvent e => new AdministratorAssigned(e.InstructorId, e.DepartmentId),
            _ => null
        };
    }
}