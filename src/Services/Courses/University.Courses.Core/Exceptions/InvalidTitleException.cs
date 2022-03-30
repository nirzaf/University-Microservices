namespace University.Courses.Core.Exceptions;

public class InvalidTitleException : DomainException
{
    public InvalidTitleException() : base("title not be empty!")
    {
    }
}