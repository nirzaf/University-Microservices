using System;
using BuildingBlocks.CQRS.Events;

namespace University.Courses.Application.Events.Rejected;

public class AddCourseRejected : IRejectedEvent
{
    public AddCourseRejected(Guid id, string reason)
    {
        Id = id;
        Reason = reason;
    }

    public Guid Id { get; }
    public string Reason { get; }
}