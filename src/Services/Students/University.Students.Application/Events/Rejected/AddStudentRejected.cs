using System;
using BuildingBlocks.CQRS.Events;

namespace University.Students.Application.Events.Rejected;

public class AddStudentRejected : IRejectedEvent
{
    public AddStudentRejected(Guid id, string reason)
    {
        Id = id;
        Reason = reason;
    }

    public Guid Id { get; }
    public string Reason { get; }
}