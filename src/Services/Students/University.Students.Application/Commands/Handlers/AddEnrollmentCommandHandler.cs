using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.CQRS.Commands;
using University.Students.Application.Services;
using University.Students.Core.Entities;

namespace University.Students.Application.Commands.Handlers;

public class AddEnrollmentCommandHandler : ICommandHandler<AddEnrollmentCommand>
{
    private readonly IEventProcessor _eventProcessor;
    private readonly IStudentDbContext _studentDbContext;

    public AddEnrollmentCommandHandler(IStudentDbContext studentDbContext, IEventProcessor eventProcessor)
    {
        _studentDbContext = studentDbContext;
        _eventProcessor = eventProcessor;
    }

    public async Task HandleAsync(AddEnrollmentCommand command, CancellationToken token)
    {
        var enrollment = Enrollment.CreateNew(command.StudentId, command.CourseId);

        await _studentDbContext.Enrollments.AddAsync(enrollment, token);

        await _eventProcessor.ProcessAsync(enrollment.Events);

        await _studentDbContext.CommitTransactionAsync(token);
    }
}