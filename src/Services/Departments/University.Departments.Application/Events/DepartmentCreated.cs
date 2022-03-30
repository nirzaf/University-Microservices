using System;
using BuildingBlocks.CQRS.Events;

namespace University.Departments.Application.Events;

public class DepartmentCreated : IEvent
{
    public DepartmentCreated(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}