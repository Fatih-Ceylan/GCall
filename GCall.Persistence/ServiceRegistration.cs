using GCall.Application.Repositories.ReadRepository.Definitions;
using GCall.Application.Repositories.WriteRepository.Definitions;
using GCall.Domain.Entities.Identity;
using GCall.Persistence.Contexts;
using GCall.Persistence.Contexts.IdentityDbContext;
using GCall.Persistence.Repositories.ReadRepository.Definitions;
using GCall.Persistence.Repositories.WriteRepository.Definitions;
using GCall.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace GCall.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<GCallDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            services.AddDbContext<AspCoreIdentityDbContext>(options => options.UseSqlServer(Configuration.IdentityConnectionString));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                //TODO: bu alan kurallandırılacak.
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AspCoreIdentityDbContext>();



            #region Definitions
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

            services.AddScoped<ICompanyReadRepository, CompanyReadRepository>();
            services.AddScoped<ICompanyWriteRepository, CompanyWriteRepository>();

            services.AddScoped<IBranchReadRepository, BranchReadRepository>();
            services.AddScoped<IBranchWriteRepository, BranchWriteRepository>();

            services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
            services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();
            #endregion

        }
    }
}
