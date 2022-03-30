using BuildingBlocks.CQRS.Commands;
using Microsoft.AspNetCore.Identity;
using University.Identity.Application.Identity.Exceptions;
using University.Identity.Core.Core;
using University.Identity.Core.Models;

namespace University.Identity.Application.Identity.Commands.Handlers;

public class RegisterNewUserCommandHandler : ICommandHandler<RegisterNewUserCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public RegisterNewUserCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task HandleAsync(RegisterNewUserCommand command, CancellationToken cancellationToken)
    {
        var applicationUser = new ApplicationUser
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            UserName = command.Username,
            Email = command.Email,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var identityResult = await _userManager.CreateAsync(applicationUser, command.Password);
        var roleResult = await _userManager.AddToRoleAsync(applicationUser, Constants.Role.User);

        if (identityResult.Succeeded == false)
            throw new RegisterIdentityUserException(string.Join(',', identityResult.Errors.Select(e => e.Description)));

        if (roleResult.Succeeded == false)
            throw new RegisterIdentityUserException(string.Join(',', roleResult.Errors.Select(e => e.Description)));
    }
}