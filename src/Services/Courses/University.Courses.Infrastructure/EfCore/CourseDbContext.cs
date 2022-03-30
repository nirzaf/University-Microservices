using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using University.Courses.Application;
using University.Courses.Core.Entities;
using University.Courses.Infrastructure.Configurations;

namespace University.Courses.Infrastructure.EfCore;

public class CourseDbContext : DbContext, ICourseDbContext
{
    private IDbContextTransaction _currentTransaction;

    public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        if (_currentTransaction != null) return;

        _currentTransaction = await Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        try
        {
            await SaveChangesAsync(cancellationToken);

            await (_currentTransaction?.CommitAsync(cancellationToken) ?? Task.CompletedTask);
        }
        catch
        {
            await RollbackTransactionAsync(cancellationToken);
            throw;
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken)
    {
        try
        {
            await _currentTransaction!.RollbackAsync(cancellationToken);
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CourseTypeConfiguration());
    }
}