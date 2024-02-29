using GCall.Application.Absractions.Token;
using GCall.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace GCall.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
       }
    }
}
