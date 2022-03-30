using System;
using BuildingBlocks.Types;
using University.Instructors.Core.Events;

namespace University.Instructors.Core.Entities;

public class CourseAssignment : BaseAggregateRoot<CourseAssignment, Guid>
{
    public CourseAssignment(Guid id, Guid instructorId, Guid courseId)
    {
        Id = id;
        InstructorId = instructorId;
        CourseId = courseId;

        AddEvent(new AssignmentCourseCreatedDomainEvent(this));
    }

    public Guid InstructorId { get; }
    public Guid CourseId { get; }

    public static CourseAssignment CreateNew(Guid instructorId, Guid courseId)
    {
        return new CourseAssignment(Guid.NewGuid(), instructorId, courseId);
    }
}