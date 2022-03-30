using System;

namespace University.Students.Core.Exceptions;

public abstract class DomainException : Exception
{
    protected DomainException(string message) : base(message)
    {
    }

    public virtual string Code { get; }
}