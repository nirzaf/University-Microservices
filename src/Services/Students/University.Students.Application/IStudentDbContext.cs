using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University.Students.Core.Entities;

namespace University.Students.Application;

public interface IStudentDbContext
{
    DbSet<Student> Students { get; }
    DbSet<Enrollment> Enrollments { get; }
    Task BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitTransactionAsync(CancellationToken cancellationToken);
    Task RollbackTransactionAsync(CancellationToken cancellationToken);
}