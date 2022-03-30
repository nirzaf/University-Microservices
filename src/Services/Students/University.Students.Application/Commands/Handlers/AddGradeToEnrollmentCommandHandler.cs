using System;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.CQRS.Commands;
using University.Students.Application.Services;

namespace University.Students.Application.Commands.Handlers;

public class AddGradeToEnrollmentCommandHandler : ICommandHandler<AddGradeToEnrollmentCommand>
{
    private readonly IEventProcessor _eventProcessor;
    private readonly IStudentDbContext _studentDbContext;

    public AddGradeToEnrollmentCommandHandler(IStudentDbContext studentDbContext, IEventProcessor eventProcessor)
    {
        _studentDbContext = studentDbContext;
        _eventProcessor = eventProcessor;
    }

    public async Task HandleAsync(AddGradeToEnrollmentCommand command, CancellationToken token)
    {
        var enrollment = await _studentDbContext.Enrollments.FindAsync(command.EnrollmentId);

        if (enrollment == null) throw new Exception("enrollment must exist.");

        enrollment.AddGrade(command.Grade);

        _studentDbContext.Enrollments.Update(enrollment);

        await _eventProcessor.ProcessAsync(enrollment.Events);

        await _studentDbContext.CommitTransactionAsync(token);
    }
}