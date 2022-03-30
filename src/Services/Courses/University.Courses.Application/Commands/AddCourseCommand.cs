using System;
using BuildingBlocks.CQRS.Commands;

namespace University.Courses.Application.Commands;

public class AddCourseCommand : ICommand
{
    public AddCourseCommand(Guid id, string title, int credits, Guid departmentId)
    {
        Id = id == Guid.Empty ? Guid.NewGuid() : id;
        Title = title;
        Credits = credits;
        DepartmentId = departmentId;
    }

    public Guid Id { get; }
    public string Title { get; }
    public int Credits { get; }
    public Guid? DepartmentId { get; }
}