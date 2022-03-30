using System.Threading.Tasks;
using BuildingBlocks.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;
using University.Instructors.Application.Commands;

namespace University.Instructors.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseAssignmentController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public CourseAssignmentController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost(nameof(Create))]
    public async Task<ActionResult> Create(AddCourseAssignmentCommand command)
    {
        await _commandDispatcher.SendAsync(command);
        return Ok();
    }
}