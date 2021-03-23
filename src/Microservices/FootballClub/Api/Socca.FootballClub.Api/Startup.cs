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
using Socca.FootballClub.Application.Interfaces;
using Socca.FootballClub.Application.Services;
using Socca.FootballClub.Data.Context;
using Socca.FootballClub.Data.Repository;
using Socca.FootballClub.Domain.CommandHandlers;
using Socca.FootballClub.Domain.Commands;
using Socca.FootballClub.Domain.Interfaces;
using Socca.Infrastructure.IoC;

namespace Socca.FootballClub.Api
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
                services.AddDbContext<FootballClubDbContext>(c =>
                    c.UseSqlServer(Configuration.GetConnectionString("WindowsDbConnection")));
            else if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
                services.AddDbContext<FootballClubDbContext>(c =>
                    c.UseSqlServer(Configuration.GetConnectionString("LinuxDbConnection")));

            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Socca.FootballClub.Api", Version = "v1" });
            });

            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {

            // Data
            services.AddTransient<IFootballClubRepository, FootballClubRepository>();
            services.AddTransient<FootballClubDbContext>();

            // Application Services
            services.AddTransient<IFootballClubService, FootballClubService>();

            // Commands
            services.AddTransient<IRequestHandler<CreateLinkToStadiumCommand, bool>, LinkToStadiumCommandHandler>();

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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Socca.FootballClub.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
