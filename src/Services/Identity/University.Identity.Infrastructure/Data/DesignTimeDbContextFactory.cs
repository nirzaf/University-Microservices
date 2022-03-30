using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace University.Identity.Infrastructure.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdentityContext>
{
    public IdentityContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<IdentityContext>();

        builder.UseSqlServer(
            "Data Source=.\\sqlexpress;Initial Catalog=Identity;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30");
        return new IdentityContext(builder.Options);
    }
}