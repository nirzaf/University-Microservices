using System;
using BuildingBlocks.Types;

namespace University.Departments.Core.Events;

public class AdministratorAssignedDomainEvent : IDomainEvent
{
    public AdministratorAssignedDomainEvent(Guid instructorId, Guid departmentId)
    {
        InstructorId = instructorId;
        DepartmentId = departmentId;
    }

    public Guid InstructorId { get; }
    public Guid DepartmentId { get; }
}