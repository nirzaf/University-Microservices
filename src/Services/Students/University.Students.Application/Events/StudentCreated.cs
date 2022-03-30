using System;
using BuildingBlocks.CQRS.Events;

namespace University.Students.Application.Events;

public class StudentCreated : IEvent
{
    public StudentCreated(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}