using System;
using BuildingBlocks.Types;
using University.Instructors.Core.ValueObjects;

namespace University.Instructors.Core.Events;

public class InstructorCreatedDomainEvent : IDomainEvent
{
    public InstructorCreatedDomainEvent(Guid id, string lastName, string firstName, DateTime hireDate,
        OfficeLocation officeLocation)
    {
        Id = id;
        LastName = lastName;
        FirstName = firstName;
        HireDate = hireDate;
        OfficeLocation = officeLocation;
    }

    public Guid Id { get; }
    public string LastName { get; }
    public string FirstName { get; }
    public DateTime HireDate { get; }
    public OfficeLocation OfficeLocation { get; }
}