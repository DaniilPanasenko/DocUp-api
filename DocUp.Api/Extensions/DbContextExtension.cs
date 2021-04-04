using System;
using DocUp.Dal.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocUp.Api.Extensions
{
    public static class DbContextExtension
    {
        /// <summary>
        /// Register Db contexts
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Configuration</param>
        /// <returns></returns>
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<DocUpContext>(
                   options =>
                       options.UseNpgsql(
                           configuration.GetConnectionString("connectionString"),
                           x => x.MigrationsAssembly("DocUp.Dal")));

            return services;
        }
    }
}
