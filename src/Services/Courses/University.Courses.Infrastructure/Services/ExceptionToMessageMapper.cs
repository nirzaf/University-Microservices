using System;
using BuildingBlocks.CQRS.Events;
using BuildingBlocks.Exception;
using University.Courses.Application.Events.Rejected;
using University.Courses.Application.Exceptions;

namespace University.Courses.Infrastructure.Services;

public class ExceptionToMessageMapper : IExceptionToMessageMapper
{
    public IRejectedEvent Map(Exception exception, object message)
    {
        return exception switch
        {
            DuplicateTitleException ex => new AddCourseRejected(ex.Id, ex.Message),
            _ => null
        };
    }
}