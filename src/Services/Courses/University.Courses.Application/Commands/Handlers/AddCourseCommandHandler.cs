using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.CQRS.Commands;
using University.Courses.Application.Exceptions;
using University.Courses.Application.Services;
using University.Courses.Core.Entities;

namespace University.Courses.Application.Commands.Handlers;

public class AddCourseCommandHandler : ICommandHandler<AddCourseCommand>
{
    private readonly ICourseDbContext _courseDbContext;
    private readonly IEventProcessor _eventProcessor;

    public AddCourseCommandHandler(ICourseDbContext courseDbContext, IEventProcessor eventProcessor)
    {
        _courseDbContext = courseDbContext;
        _eventProcessor = eventProcessor;
    }

    public async Task HandleAsync(AddCourseCommand command, CancellationToken token)
    {
        var duplicateTitle = _courseDbContext.Courses.Any(x => x.Title == command.Title);
        if (duplicateTitle) throw new DuplicateTitleException(command.Id);

        var course = Course.Create(command.Id, command.DepartmentId, command.Title, command.Credits);
        await _courseDbContext.Courses.AddAsync(course, token);

        await _eventProcessor.ProcessAsync(course.Events);

        await _courseDbContext.CommitTransactionAsync(token);
    }
}