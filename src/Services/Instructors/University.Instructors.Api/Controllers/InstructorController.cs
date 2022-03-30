using System.Threading.Tasks;
using BuildingBlocks.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;
using University.Instructors.Application.Commands;

namespace University.Instructors.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstructorController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public InstructorController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost(nameof(Create))]
    public async Task<ActionResult> Create(AddInstructorCommand command)
    {
        await _commandDispatcher.SendAsync(command);
        return Ok();
    }
}