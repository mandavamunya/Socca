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
using Socca.FootballClubStadium.Application.EventHandlers;
using Socca.FootballClubStadium.Application.Events;
using Socca.FootballClubStadium.Application.Interfaces;
using Socca.FootballClubStadium.Application.Services;
using Socca.FootballClubStadium.Data.Context;
using Socca.FootballClubStadium.Data.Repository;
using Socca.FootballClubStadium.Domain.Interfaces;
using Socca.Infrastructure.IoC;

namespace Socca.FootballClubStadium.Api
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
                services.AddDbContext<FootballClubStadiumDbContext>(c =>
                    c.UseSqlServer(Configuration.GetConnectionString("WindowsDbConnection")));
            else if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
                services.AddDbContext<FootballClubStadiumDbContext>(c =>
                    c.UseSqlServer(Configuration.GetConnectionString("LinuxDbConnection")));

            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Socca.FootballClubStadium.Api", Version = "v1" });
            });

            services.AddMediatR(typeof(Startup));

            // Add memory cache services
            services.AddMemoryCache();

            // services.AddHsts(options =>
            // {
            //    options.Preload = true;
            //    options.IncludeSubDomains = true;
            //    options.MaxAge = TimeSpan.FromDays(60);
            // });

            services.AddMediatR(typeof(Startup));

            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            // Subsciptions
            services.AddTransient<LinkToStadiumEventHandler>();

            // Domain Events
            services.AddTransient<IEventHandler<LinkToStadiumCreatedEvent>, LinkToStadiumEventHandler>();

            // Data
            services.AddTransient<IFootballClubStadiumRepository, FootballClubStadiumRepository>();
            services.AddTransient<FootballClubStadiumDbContext>();

            // Application Services
            services.AddTransient<IFootballClubStadiumService, FootballClubStadiumService>();

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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Socca.FootballClubStadium.Api v1"));
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Socca.FootballClub.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
