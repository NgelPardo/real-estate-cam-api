﻿using Microsoft.Extensions.DependencyInjection;

namespace RealEstateCam.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            return services;
        }
    }
}
