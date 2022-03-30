using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace University.Courses.Infrastructure.EfCore;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CourseDbContext>
{
    public CourseDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<CourseDbContext>();

        builder.UseSqlServer(
            "Data Source=.\\sqlexpress;Initial Catalog=Course;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30");
        return new CourseDbContext(builder.Options);
    }
}