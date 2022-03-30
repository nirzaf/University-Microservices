using System.Collections.Generic;
using System.Threading.Tasks;
using BuildingBlocks.Types;

namespace University.Instructors.Application.Services;

public interface IEventProcessor
{
    Task ProcessAsync(IEnumerable<IDomainEvent> events);
}