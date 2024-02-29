using GCall.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GCall.Persistence.Contexts.IdentityDbContext
{
    public class AspCoreIdentityDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AspCoreIdentityDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
