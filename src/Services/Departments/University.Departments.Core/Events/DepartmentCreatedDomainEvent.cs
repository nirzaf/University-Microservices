using System;
using BuildingBlocks.Types;

namespace University.Departments.Core.Events;

public class DepartmentCreatedDomainEvent : IDomainEvent
{
    public DepartmentCreatedDomainEvent(Guid id, string name, decimal budget, DateTime startDate,
        Guid? instructorId)
    {
        Id = id;
        Name = name;
        Budget = budget;
        StartDate = startDate;
        InstructorId = instructorId;
    }

    public Guid Id { get; }
    public string Name { get; }
    public decimal Budget { get; }
    public DateTime StartDate { get; }
    public Guid? InstructorId { get; }
}