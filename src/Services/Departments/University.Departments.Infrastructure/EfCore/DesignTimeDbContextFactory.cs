using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace University.Departments.Infrastructure.EfCore;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DepartmentDbContext>
{
    public DepartmentDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<DepartmentDbContext>();

        builder.UseSqlServer(
            "Data Source=.\\sqlexpress;Initial Catalog=Department;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30");
        return new DepartmentDbContext(builder.Options);
    }
}