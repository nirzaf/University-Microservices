using System;
using BuildingBlocks.Types;

namespace University.Courses.Core.Events;

public class CourseCreatedDomainEvent : IDomainEvent
{
    public CourseCreatedDomainEvent(Guid id, int credits, string title, Guid? departmentId)
    {
        Id = id;
        Title = title;
        Credits = credits;
        DepartmentId = departmentId;
    }

    public Guid Id { get; }
    public string Title { get; }
    public int Credits { get; }
    public Guid? DepartmentId { get; }
}