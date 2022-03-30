using System;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.CQRS.Commands;
using University.Departments.Application.Services;

namespace University.Departments.Application.Commands.Handlers;

public class AssignAdministratorCommandHandler : ICommandHandler<AssignAdministratorCommand>
{
    private readonly IDepartmentDbContext _departmentDbContext;
    private readonly IEventProcessor _eventProcessor;

    public AssignAdministratorCommandHandler(IDepartmentDbContext departmentDbContext,
        IEventProcessor eventProcessor)
    {
        _departmentDbContext = departmentDbContext;
        _eventProcessor = eventProcessor;
    }

    public async Task HandleAsync(AssignAdministratorCommand command, CancellationToken token)
    {
        var department = await _departmentDbContext.Departments.FindAsync(command.DepartmentId);

        if (department == null) throw new Exception("department must exist.");

        department.AssignAdministrator(command.InstructorId);

        _departmentDbContext.Departments.Update(department);

        await _eventProcessor.ProcessAsync(department.Events);

        await _departmentDbContext.CommitTransactionAsync(token);
    }
}