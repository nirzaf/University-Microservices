using System.Threading.Tasks;
using BuildingBlocks.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;
using University.Students.Application.Commands;

namespace University.Students.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnrollmentController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public EnrollmentController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost(nameof(Create))]
    public async Task<ActionResult> Create(AddEnrollmentCommand command)
    {
        await _commandDispatcher.SendAsync(command);
        return Ok();
    }
}