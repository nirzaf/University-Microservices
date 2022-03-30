using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.CQRS.Events;
using BuildingBlocks.Types;
using University.Students.Application.Events;
using University.Students.Application.Services;
using University.Students.Core.Events;

namespace University.Students.Infrastructure.Services;

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
            StudentCreatedDomainEvent e => new StudentCreated(e.Id),
            EnrollmentCreatedDomainEvent e => new EnrollmentCreated(e.Id, e.StudentId, e.CourseId),
            _ => null
        };
    }
}