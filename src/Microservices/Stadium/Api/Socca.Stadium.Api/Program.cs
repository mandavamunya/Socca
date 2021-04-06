using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Socca.Stadium.Data.Context;

namespace Socca.Stadium.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var loggerFactory = provider.GetRequiredService<ILoggerFactory>();

                var context = provider.GetRequiredService<StadiumDbContext>();

                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred while migrating the DB");
                }


                try
                {
                    StadiumDbContexSeeder.SeedAsync(context, loggerFactory).Wait();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB's table.");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureKestrel(o =>
                    {
                        o.ConfigureHttpsDefaults(o =>
                        o.ClientCertificateMode =
                        Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode.RequireCertificate);
                    });
                });
    }
}
