using GCall.Persistence.Contexts;
using GCall.Persistence.Services;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCall.Persistence.Contexts.IdentityDbContext;

namespace GCall.Persistence
{
    public class DesignTimeDbContextFactoryIdentity : IDesignTimeDbContextFactory<AspCoreIdentityDbContext>
    {
        public AspCoreIdentityDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AspCoreIdentityDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.IdentityConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }


    }
}
