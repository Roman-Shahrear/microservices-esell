﻿using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection services)
        {
            // Services.AddMediatR(cfg => {
            //        cfg.RegisterServicesFromAssembly(AssemblyLoadEventArgs.GetExecutingAssembly());
            // });

            return services;
        }
    }
}
