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
using Socca.Domain.Core.Bus;
using Socca.Infrastructure.IoC;
using Socca.PlayerTransfers.Application.EventHandlers;
using Socca.PlayerTransfers.Application.Events;
using Socca.PlayerTransfers.Application.Interfaces;
using Socca.PlayerTransfers.Application.Services;
using Socca.PlayerTransfers.Data.Context;
using Socca.PlayerTransfers.Data.Repository;
using Socca.PlayerTransfers.Domain.Interfaces;

namespace Socca.PlayerTransfers.Api
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
                services.AddDbContext<PlayerTransferDbContext>(c =>
                    c.UseSqlServer(Configuration.GetConnectionString("WindowsDbConnection")));
            else if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
                services.AddDbContext<PlayerTransferDbContext>(c =>
                    c.UseSqlServer(Configuration.GetConnectionString("LinuxDbConnection")));

            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Socca.PlayerTransfers.Api", Version = "v1" });
            });

            services.AddMediatR(typeof(Startup));

            // Add memory cache services
            services.AddMemoryCache();

            //services.AddHsts(options =>
            //{
            //    options.Preload = true;
            //    options.IncludeSubDomains = true;
            //    options.MaxAge = TimeSpan.FromDays(60);
            //options.ExcludedHosts.Add("example.com");
            //options.ExcludedHosts.Add("www.example.com");
            //});

            services.AddMediatR(typeof(Startup));

            RegisterServices(services);

        }

        private void RegisterServices(IServiceCollection services)
        {
            // Subsciptions
            services.AddTransient<PlayerTransferEventHandler>();

            // Domain Events
            services.AddTransient<IEventHandler<PlayerTransferCreatedEvent>, PlayerTransferEventHandler>();

            // Data
            services.AddTransient<IPlayerTransferRepository, PlayerTransferRepository>();
            services.AddTransient<PlayerTransferDbContext>();

            // Application Services
            services.AddTransient<IPlayerTransferService, PlayerTransferService>();
            // Infrastructure e.g. Bus
            DependencyContainer.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Socca.PlayerTransfers.Api v1"));
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Socca.PlayerTransfers.Api v1"));
            }


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureEventBus(app);
        }

        private static void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<PlayerTransferCreatedEvent, PlayerTransferEventHandler>();
        }

    }
}
