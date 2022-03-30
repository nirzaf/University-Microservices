namespace University.Courses.Core.Exceptions;

public class InvalidCreditsException : DomainException
{
    public InvalidCreditsException() : base("credits must be greater than 0!")
    {
    }
}