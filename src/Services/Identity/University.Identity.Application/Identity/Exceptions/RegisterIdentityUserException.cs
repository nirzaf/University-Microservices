namespace University.Identity.Application.Identity.Exceptions;

public class RegisterIdentityUserException : AppException
{
    public RegisterIdentityUserException(string error) : base(error)
    {
    }
}