using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Socca.Stadium.Api", Version = "v1" });
            });
            services.AddTransient<IStadiumRepository, StadiumRepository>();
            services.AddTransient<IStadiumService, StadiumService>();
            services.AddTransient<StadiumDbContext>();
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
