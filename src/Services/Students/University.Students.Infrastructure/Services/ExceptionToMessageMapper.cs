using System;
using BuildingBlocks.CQRS.Events;
using BuildingBlocks.Exception;
using University.Students.Application.Events.Rejected;

namespace University.Students.Infrastructure.Services;

public class ExceptionToMessageMapper : IExceptionToMessageMapper
{
    public IRejectedEvent Map(Exception exception, object message)
    {
        return exception switch
        {
            DuplicateException ex => new AddStudentRejected(ex.Id, ex.Message),
            _ => null
        };
    }
}