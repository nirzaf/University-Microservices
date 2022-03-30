using System;
using BuildingBlocks.Types;
using University.Instructors.Core.Entities;

namespace University.Instructors.Core.Events;

public class AssignmentCourseCreatedDomainEvent : IDomainEvent
{
    public AssignmentCourseCreatedDomainEvent(CourseAssignment courseAssignment)
    {
        Id = courseAssignment.Id;
        InstructorId = courseAssignment.InstructorId;
        CourseId = courseAssignment.CourseId;
    }

    public Guid Id { get; }
    public Guid InstructorId { get; }
    public Guid CourseId { get; }
}