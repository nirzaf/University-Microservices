using System;

namespace University.Courses.Application.Exceptions;

public class DuplicateTitleException : AppException
{
    public DuplicateTitleException(Guid id) : base("title already exist!")
    {
        Id = id;
    }

    public Guid Id { get; }
}