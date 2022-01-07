using System;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Socca.Infrastructure.IoC;
using Socca.Stadium.Application.Interfaces;
using Socca.Stadium.Application.Services;
using Socca.Stadium.Data.Context;
using Socca.Stadium.Data.Repository;
using Socca.Stadium.Domain.Interfaces;

namespace Socca.Stadium.Api
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

            if (OperatingSystem.IsWindows())
                services.AddDbContext<StadiumDbContext>(c =>
                    c.UseSqlServer(Configuration.GetConnectionString("WindowsDbConnection")));
            else if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
                services.AddDbContext<StadiumDbContext>(c =>
                    c.UseSqlServer(Configuration.GetConnectionString("LinuxDbConnection")));

            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Socca.Stadium.Api", Version = "v1" });
            });

            // Add memory cache services
            services.AddMemoryCache();

            services.AddMediatR(typeof(Startup));

            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            // Data
            services.AddTransient<IStadiumRepository, StadiumRepository>();
            services.AddTransient<StadiumDbContext>();

            // Application Services
            services.AddTransient<IStadiumService, StadiumService>();

            // infrastructure e.g. Bus
            DependencyContainer.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Socca.Stadium.Api v1"));
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Socca.Stadium.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapHealthChecks("/health");
            });
        }
    }
}
