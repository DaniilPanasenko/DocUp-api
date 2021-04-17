using System;
using DocUp.Api.Auth;
using DocUp.Bll;
using DocUp.Bll.Services;
using DocUp.Bll.Services.Impl;
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

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IIlnessService, IlnessService>();
            services.AddTransient<IDeviceService, DeviceService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IClinicService, ClinicService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<INotificationService, NotificationService>();

            services.AddTransient<ReadingsHandler>();
            services.AddSingleton<NotificationsBus>();
            services.AddSingleton<ReadingsTimeCheck>();

            services.AddScoped<IApplicationUser, ApplicationUser>();

            return services;
        }
    }
}
