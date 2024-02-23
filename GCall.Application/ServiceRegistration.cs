using Microsoft.Extensions.DependencyInjection;
using System;
using MediatR;
using GCall.Application.Models;

namespace GCall.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
