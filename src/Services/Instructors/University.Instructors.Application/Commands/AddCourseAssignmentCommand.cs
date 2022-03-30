using System;
using BuildingBlocks.CQRS.Commands;

namespace University.Instructors.Application.Commands;

public class AddCourseAssignmentCommand : ICommand
{
    public Guid InstructorId { get; private set; }
    public Guid CourseId { get; private set; }
}