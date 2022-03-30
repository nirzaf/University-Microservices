using System;
using University.Students.Application.Exceptions;

public class DuplicateException : AppException
{
    public DuplicateException(Guid id) : base("title already exist!")
    {
        Id = id;
    }

    public Guid Id { get; }
}