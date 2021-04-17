using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Socca.DistributedCache.Application.EventHandlers;
using Socca.DistributedCache.Application.Events;
using Socca.DistributedCache.Application.Services;
using Socca.DistributedCache.Data.Context;
using Socca.DistributedCache.Domain.Interfaces;
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
            // Redis
            services.AddStackExchangeRedisCache(options => {
                options.Configuration = Configuration.GetValue<string>("Redis:Connection");
            });

            //services.AddScoped<IDistributedCache, RedisCache>();
            services.Add(ServiceDescriptor.Singleton<IDistributedCache, RedisCache>());
    
            // Controllers
            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Socca.DistributedCache.Api", Version = "v1" });
            });
            // Add memory cache services
            services.AddMemoryCache();

            services.AddMediatR(typeof(Startup));

            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {


            // Subsciptions
            services.AddTransient<PlayerTransferEventHandler>();
            services.AddTransient<LinkToStadiumEventHandler>();

            // Domain Events
            services.AddTransient<IEventHandler<PlayerTransferCreatedEvent>, PlayerTransferEventHandler>();
            services.AddTransient<IEventHandler<LinkToStadiumCreatedEvent>, LinkToStadiumEventHandler>();

            // Data
            services.AddScoped(typeof(IDistributedCacheRepository<>), typeof(DistributedCacheRepository<>));

            // Application Services
            services.AddTransient<IPlayerTransferService, PlayerTransferService> ();
            services.AddTransient<IFootballClubToStadiumService, FootballClubToStadiumService> ();

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
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Socca.DistributedCache.Api v1"));
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
