using System;
using BuildingBlocks.CQRS.Events;

namespace University.Instructors.Application.Events;

public class AssignmentCourseCreated : IEvent
{
    public AssignmentCourseCreated(Guid id, Guid instructorId, Guid courseId)
    {
        Id = id;
        InstructorId = instructorId;
        CourseId = courseId;
    }

    public Guid Id { get; }
    public Guid InstructorId { get; }
    public Guid CourseId { get; }
}