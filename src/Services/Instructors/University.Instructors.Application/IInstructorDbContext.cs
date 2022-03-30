using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University.Instructors.Core.Entities;

namespace University.Instructors.Application;

public interface IInstructorDbContext
{
    DbSet<Instructor> Instructors { get; }
    DbSet<CourseAssignment> CourseAssignments { get; }
    Task BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitTransactionAsync(CancellationToken cancellationToken);
    Task RollbackTransactionAsync(CancellationToken cancellationToken);
}