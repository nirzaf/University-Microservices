using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.CQRS.Commands;
using University.Instructors.Application.Services;
using University.Instructors.Core.Entities;

namespace University.Instructors.Application.Commands.Handlers;

public class AddInstructorCommandHandler : ICommandHandler<AddInstructorCommand>
{
    private readonly IEventProcessor _eventProcessor;
    private readonly IInstructorDbContext _instructorDbContext;

    public AddInstructorCommandHandler(IInstructorDbContext instructorDbContext, IEventProcessor eventProcessor)
    {
        _instructorDbContext = instructorDbContext;
        _eventProcessor = eventProcessor;
    }

    public async Task HandleAsync(AddInstructorCommand command, CancellationToken token)
    {
        var instructor = Instructor.Create(command.FirstName, command.LastName, command.HireDate,
            command.OfficeLocation);
        await _instructorDbContext.Instructors.AddAsync(instructor, token);

        await _eventProcessor.ProcessAsync(instructor.Events);

        await _instructorDbContext.CommitTransactionAsync(token);
    }
}