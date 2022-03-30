using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace University.Instructors.Infrastructure.EfCore;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<InstructorDbContext>
{
    public InstructorDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<InstructorDbContext>();

        builder.UseSqlServer(
            "Data Source=.\\sqlexpress;Initial Catalog=Instructor;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30");
        return new InstructorDbContext(builder.Options);
    }
}