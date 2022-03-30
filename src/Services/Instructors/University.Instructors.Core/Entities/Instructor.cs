using System;
using BuildingBlocks.Types;
using University.Instructors.Core.Events;
using University.Instructors.Core.ValueObjects;

namespace University.Instructors.Core.Entities;

public class Instructor : BaseAggregateRoot<Instructor, Guid>
{
    public Instructor()
    {
    }

    private Instructor(Guid id, string firstName, string lastName, DateTime hireDate, OfficeLocation officeLocation)
    {
        //CheckRule(new DepartmentMustHavePositiveBudgetRule(budget));

        Id = id;
        FirstName = firstName;
        LastName = lastName;
        HireDate = hireDate;
        OfficeLocation =
            OfficeLocation.CreateNew(officeLocation.Address, officeLocation.PostalCode, officeLocation.City);

        AddEvent(new InstructorCreatedDomainEvent(id, lastName, firstName, hireDate, OfficeLocation));
    }

    public string LastName { get; }
    public string FirstName { get; }
    public DateTime HireDate { get; }
    public string FullName => LastName + " " + FirstName;
    public OfficeLocation OfficeLocation { get; }

    public static Instructor Create(string firstName, string lastName, DateTime hireDate,
        OfficeLocation officeLocation)
    {
        return new Instructor(Guid.NewGuid(), firstName, lastName, hireDate, officeLocation);
    }
}