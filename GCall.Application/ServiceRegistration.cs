using Microsoft.Extensions.DependencyInjection;
using System;
using MediatR;
 
namespace GCall.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
        }
    }
}
