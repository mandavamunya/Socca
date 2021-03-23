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
using Socca.Players.Application.Interfaces;
using Socca.Players.Application.Service;
using Socca.Players.Data.Context;
using Socca.Players.Data.Repository;
using Socca.Players.Domain.CommandHandlers;
using Socca.Players.Domain.Commands;
using Socca.Players.Domain.Interfaces;

namespace Socca.Players.Api
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
                services.AddDbContext<PlayerDbContext>(c =>
                    c.UseSqlServer(Configuration.GetConnectionString("WindowsDbConnection")));
            else if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
                services.AddDbContext<PlayerDbContext>(c =>
                    c.UseSqlServer(Configuration.GetConnectionString("LinuxDbConnection")));

            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Socca.Players.Api", Version = "v1" });
            });

            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            // Commands
            services.AddTransient<IRequestHandler<CreatePlayerTransferCommand, bool>, PlayerTransferCommandHandler>();

            // Data
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<PlayerDbContext>();

            // Application Services
            services.AddTransient<IPlayerService, PlayerService>();

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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Socca.Players.Api v1"));
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
