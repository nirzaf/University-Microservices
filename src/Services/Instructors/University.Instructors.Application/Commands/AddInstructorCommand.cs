using System;
using BuildingBlocks.CQRS.Commands;
using University.Instructors.Core.ValueObjects;

namespace University.Instructors.Application.Commands;

public class AddInstructorCommand : ICommand
{
    public string LastName { get; init; }
    public string FirstName { get; init; }
    public DateTime HireDate { get; init; }
    public OfficeLocation OfficeLocation { get; init; }
}