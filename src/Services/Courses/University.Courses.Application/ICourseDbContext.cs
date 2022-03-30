using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University.Courses.Core.Entities;

namespace University.Courses.Application;

public interface ICourseDbContext
{
    DbSet<Course> Courses { get; }
    Task BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitTransactionAsync(CancellationToken cancellationToken);
    Task RollbackTransactionAsync(CancellationToken cancellationToken);
}