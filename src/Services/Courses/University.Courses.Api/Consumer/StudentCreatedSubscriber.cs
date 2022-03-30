using System;
using DotNetCore.CAP;
using University.Courses.Application.Events.External;

namespace University.Courses.Api.Consumer;

public class StudentCreatedSubscriber : ICapSubscribe
{
    [CapSubscribe("StudentCreated")]
    public void CheckReceivedMessage(StudentCreated student)
    {
        Console.WriteLine($"We got student with id: {student.Id}");
    }
}