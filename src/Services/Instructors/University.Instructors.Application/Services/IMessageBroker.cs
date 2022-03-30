using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingBlocks.CQRS.Events;

namespace University.Instructors.Application.Services;

public interface IMessageBroker
{
    Task PublishAsync(params IEvent[] events);
    Task PublishAsync(IEnumerable<IEvent> events);
}