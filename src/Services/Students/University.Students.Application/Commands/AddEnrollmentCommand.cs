using System;
using BuildingBlocks.CQRS.Commands;

namespace University.Students.Application.Commands;

public class AddEnrollmentCommand : ICommand
{
    public AddEnrollmentCommand(Guid courseId, Guid studentId)
    {
        CourseId = courseId;
        StudentId = studentId;
    }

    public Guid CourseId { get; }
    public Guid StudentId { get; }
}