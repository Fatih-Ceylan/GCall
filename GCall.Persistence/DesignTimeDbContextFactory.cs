using GCall.Persistence.Services;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using GCall.Persistence.Contexts;

namespace GCall.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GCallDbContext>
        {
            public GCallDbContext CreateDbContext(string[] args)
            {
                DbContextOptionsBuilder<GCallDbContext> dbContextOptionsBuilder = new();
                dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
                return new(dbContextOptionsBuilder.Options);
            }
        }
}
