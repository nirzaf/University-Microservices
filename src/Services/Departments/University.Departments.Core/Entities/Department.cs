using System;
using BuildingBlocks.Types;
using University.Departments.Core.Events;

namespace University.Departments.Core.Entities;

public class Department : BaseAggregateRoot<Department, Guid>
{
    public Department()
    {
    }

    private Department(Guid id, string name, decimal budget, DateTime startDate, Guid? administratorId)
    {
        //CheckRule(new DepartmentMustHavePositiveBudgetRule(budget));
        Id = id;
        Name = name;
        Budget = budget;
        StartDate = startDate;
        InstructorId = administratorId;

        AddEvent(new DepartmentCreatedDomainEvent(id, name, budget, startDate, administratorId));
    }

    public string Name { get; set; }

    public decimal Budget { get; set; }

    public DateTime StartDate { get; set; }

    public Guid? InstructorId { get; set; }

    public static Department Create(string name, decimal budget, DateTime startDate, Guid? administratorId)
    {
        return new Department(Guid.NewGuid(), name, budget, startDate, administratorId);
    }

    public void AssignAdministrator(Guid administratorId)
    {
        InstructorId = administratorId;
        AddEvent(new AdministratorAssignedDomainEvent(administratorId, Id));
    }
}