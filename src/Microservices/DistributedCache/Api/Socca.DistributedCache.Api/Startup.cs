using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Socca.DistributedCache.Application.EventHandlers;
using Socca.DistributedCache.Application.Events;
using Socca.DistributedCache.Application.Interfaces;
using Socca.DistributedCache.Application.Services;
using Socca.Domain.Core.Bus;
using Socca.Infrastructure.IoC;

namespace Socca.DistributedCache.Api
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
            services.AddStackExchangeRedisCache(options => {
                options.Configuration = Configuration.GetValue<string>("CacheSettings:Connection");
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Socca.DistributedCache.Api", Version = "v1" });
            });
            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            // Subsciptions
            services.AddTransient<PlayerTransferEventHandler>();

            // Domain Events
            // services.AddTransient<IEventHandler<PlayerTransferCreatedEvent>, PlayerTransferEventHandler>();

            // Data
            // services.AddTransient<IDistributedCacheRepository, DistributedCacheRepository>();

            // Application Services
            services.AddTransient<IFootballClubStadiumCacheService, FootballClubStadiumCacheService>();
            services.AddTransient<IPlayerTransferCacheService, PlayerTransferCacheService>();

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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Socca.DistributedCache.Api v1"));
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
