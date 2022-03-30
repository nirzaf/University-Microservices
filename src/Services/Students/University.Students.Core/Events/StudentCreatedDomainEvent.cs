using System;
using BuildingBlocks.Types;
using University.Students.Core.Entities;

namespace University.Students.Core.Events;

public class StudentCreatedDomainEvent : IDomainEvent
{
    public StudentCreatedDomainEvent(Student student)
    {
        Id = student.Id;
        EnrollmentDate = student.EnrollmentDate;
        FirstName = student.FirstName;
        LastName = student.LastName;
    }

    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public DateTime EnrollmentDate { get; }
}