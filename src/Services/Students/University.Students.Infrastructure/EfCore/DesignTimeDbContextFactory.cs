using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace University.Students.Infrastructure.EfCore;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StudentDbContext>
{
    public StudentDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<StudentDbContext>();

        builder.UseSqlServer(
            "Data Source=.\\sqlexpress;Initial Catalog=Student;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30");
        return new StudentDbContext(builder.Options);
    }
}