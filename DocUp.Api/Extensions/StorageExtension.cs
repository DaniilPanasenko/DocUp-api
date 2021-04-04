using System;
using Microsoft.Extensions.DependencyInjection;

namespace DocUp.Api.Extensions
{
    public static class StorageExtension
    {
        /// <summary>
        /// Registers storages.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <returns>Service collection.</returns>
        public static IServiceCollection AddStorages(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            return services;
        }
    }
}
