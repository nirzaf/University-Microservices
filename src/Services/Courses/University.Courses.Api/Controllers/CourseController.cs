using System.Threading.Tasks;
using BuildingBlocks.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;
using University.Courses.Application.Commands;

namespace University.Courses.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public CourseController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost(nameof(Create))]
    public async Task<ActionResult> Create(AddCourseCommand command)
    {
        await _commandDispatcher.SendAsync(command);
        return Ok();
    }
}