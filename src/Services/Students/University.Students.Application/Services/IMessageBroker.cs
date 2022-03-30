using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingBlocks.CQRS.Events;

namespace University.Students.Application.Services;

public interface IMessageBroker
{
    Task PublishAsync(IEnumerable<IEvent> events);
}