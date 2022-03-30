using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.CQRS.Events;
using BuildingBlocks.Types;
using University.Instructors.Application.Events;
using University.Instructors.Application.Services;
using University.Instructors.Core.Events;

namespace University.Instructors.Infrastructure.Services;

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
            InstructorCreatedDomainEvent e => new InstructorCreated(e.Id),
            AssignmentCourseCreatedDomainEvent e => new AssignmentCourseCreated(e.Id, e.InstructorId, e.CourseId),
            _ => null
        };
    }
}