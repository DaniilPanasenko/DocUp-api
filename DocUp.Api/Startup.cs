using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocUp.Api.Extensions;
using DocUp.Dal.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace DocUp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddCors();
            services.AddMemoryCache();
            services.AddHttpContextAccessor();

            services.AddSwagger();
            services.AddAuthentications();
            services.AddDbContexts(Configuration);
            services.AddAutoMapper(c => c.AddProfile<MappingProfile>(), typeof(Startup));
            services.AddServices();
            services.AddStorages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DocUpContext dbContext)
        {
            dbContext?.Database.Migrate();

            SeedingExtension.EnsureAdminCreated(dbContext);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DocUp v1"));
            }

            app.UseCors(builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("Authorization", "Accept", "Content-Type", "Origin"));

            app.UseMiddleware<LoggingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
