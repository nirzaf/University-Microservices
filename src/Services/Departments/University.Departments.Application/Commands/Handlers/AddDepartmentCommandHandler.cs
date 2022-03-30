using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.CQRS.Commands;
using University.Departments.Application.Services;
using University.Departments.Core.Entities;

namespace University.Departments.Application.Commands.Handlers;

public class AddDepartmentCommandHandler : ICommandHandler<AddDepartmentCommand>
{
    private readonly IDepartmentDbContext _departmentDbContext;
    private readonly IEventProcessor _eventProcessor;

    public AddDepartmentCommandHandler(IEventProcessor eventProcessor, IDepartmentDbContext departmentDbContext)
    {
        _eventProcessor = eventProcessor;
        _departmentDbContext = departmentDbContext;
    }

    public async Task HandleAsync(AddDepartmentCommand command, CancellationToken token)
    {
        var department =
            Department.Create(command.Name, command.Budget, command.StartDate, command?.AdministratorId);
        await _departmentDbContext.Departments.AddAsync(department, token);

        await _eventProcessor.ProcessAsync(department.Events);

        await _departmentDbContext.CommitTransactionAsync(token);
    }
}