using System;
using BuildingBlocks.CQRS.Events;

namespace University.Instructors.Application.Events;

public class InstructorCreated : IEvent
{
    public InstructorCreated(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}