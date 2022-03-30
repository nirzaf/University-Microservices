using BuildingBlocks.CQRS.Events;
using BuildingBlocks.Types;
using University.Courses.Application.Events;
using University.Courses.Application.Services;
using University.Courses.Core.Events;

namespace University.Courses.Infrastructure.Services;

internal sealed class EventMapper : IEventMapper
{
    public IEvent Map(IDomainEvent @event)
    {
        return @event switch
        {
            CourseCreatedDomainEvent e => new CourseCreated(e.Id),
            _ => null
        };
    }
}