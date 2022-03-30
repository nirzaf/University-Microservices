using BuildingBlocks.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;
using University.Identity.Application.Identity.Commands;

namespace Identity.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public IdentityController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost(nameof(RegisterNewUser))]
    public async Task<ActionResult> RegisterNewUser(RegisterNewUserCommand command)
    {
        await _commandDispatcher.SendAsync(command);
        return Ok();
    }
}