using System;
using DocUp.Dal.Storages;
using DocUp.Dal.Storages.Impl;
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

            services.AddTransient<IAccountStorage, AccountStorage>();
            services.AddTransient<IDeviceStorage, DeviceStorage>();
            services.AddTransient<IIlnessStorage, IlnessStorage>();
            services.AddTransient<IDoctorStorage, DoctorStorage>();
            services.AddTransient<IPatientStorage, PatientStorage>();
            services.AddTransient<IClinicStorage, ClinicStorage>();

            return services;
        }
    }
}
