using System;
using Microsoft.Extensions.DependencyInjection;

namespace DocUp.Api.Extensions
{
    public static class ServiceExtension
    {
        /// <summary>
        /// Registers services.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <returns>Service collection.</returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));


            return services;
        }
    }
}
