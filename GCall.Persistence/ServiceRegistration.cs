using GCall.Application.Repositories.ReadRepository.Definitions;
using GCall.Persistence.Contexts;
using GCall.Persistence.Repositories.ReadRepository.Definitions;
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

            #region Definitions
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();

            #endregion
        }
    }
}
