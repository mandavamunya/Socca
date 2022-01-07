using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Socca.UI.Providers.Interfaces;
using Socca.UI.Providers.Services;

namespace Socca.UI.Web
{
    public class Startup
    {

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();


            //services.AddHttpClient<IDistributedCacheService, DistributedCacheService>(client =>
            //{
            //    client.BaseAddress = new Uri(Configuration.GetSection("ServiceProviders")["DistributedCacheBase"]);
            //});

            //services.AddHttpClient<IFootballClubService, FootballClubService>(client =>
            //{
            //    client.BaseAddress = new Uri(Configuration.GetSection("ServiceProviders")["FootballClubBase"]);
            //}); 

            //services.AddHttpClient<IFootballClubStadiumService, FootballClubStadiumService>(client =>
            //{
            //    client.BaseAddress = new Uri(Configuration.GetSection("ServiceProviders")["FootballClubStadiumBase"]);
            //});

            //services.AddHttpClient<IPlayerService, PlayerService>(client =>
            //{
            //    client.BaseAddress = new Uri(Configuration.GetSection("ServiceProviders")["PlayerBase"]);
            //});

            //services.AddHttpClient<IStadiumService, StadiumService>(client =>
            //{
            //    client.BaseAddress = new Uri(Configuration.GetSection("ServiceProviders")["StadiumBase"]);
            //});

            //services.AddHttpClient<IPlayerTransferService, PlayerTransferService>(client =>
            //{
            //    client.BaseAddress = new Uri(Configuration.GetSection("ServiceProviders")["PlayerTransferBase"]);
            //});

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins(Configuration.GetValue<string>("Settings:AllowedOrigins"));
                                  });
            });

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //The default HSTS value is 30 days.You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                //if (env.IsDevelopment())
                //{
                //    var baseUrl = Configuration.GetValue<string>("ClientBaseUrl");
                //    spa.UseProxyToSpaDevelopmentServer(baseUrl);
                //    //spa.UseReactDevelopmentServer(npmScript: "start");
                //}
            });

            app.UseEndpoints(endPoints => {
                endPoints.MapControllers().RequireCors(MyAllowSpecificOrigins);
            });
        }
    }
}
