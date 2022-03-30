using System;
using BuildingBlocks.CQRS.Events;

namespace University.Courses.Application.Events.External;

public class StudentCreated : IEvent
{
    public StudentCreated(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}