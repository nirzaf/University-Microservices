using BuildingBlocks.CQRS.Commands;

namespace University.Identity.Application.Identity.Commands;

public record RegisterNewUserCommand(string FirstName, string LastName, string Username, string Email, string Password,
    string ConfirmPassword) : ICommand;