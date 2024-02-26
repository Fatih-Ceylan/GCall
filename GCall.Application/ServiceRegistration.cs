using Microsoft.Extensions.DependencyInjection;
using System;
using MediatR;
using GCall.Application.Models;
using System.Reflection;

namespace GCall.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
