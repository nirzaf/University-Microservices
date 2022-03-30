using System;
using BuildingBlocks.Types;
using University.Students.Core.Entities;

namespace University.Students.Core.Events;

public class EnrollmentCreatedDomainEvent : IDomainEvent
{
    public EnrollmentCreatedDomainEvent(Enrollment enrollment)
    {
        Id = enrollment.Id;
        CourseId = enrollment.CourseId;
        StudentId = enrollment.StudentId;
        Grade = enrollment!.Grade;
    }

    public Guid Id { get; set; }
    public Guid CourseId { get; }
    public Guid StudentId { get; }
    public Grade? Grade { get; }
}