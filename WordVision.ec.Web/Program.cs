using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
//using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Infrastructure.Data.Identity.Models;

namespace WordVision.ec.Web
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File("Logs/mylog.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            try
            {
                Log.Information("Starting Web Host");
                var host = CreateHostBuilder(args).Build();
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    //var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                    //var logger = loggerFactory.CreateLogger("app");
                    try
                    {
                        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                        await Infrastructure.Data.Identity.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
                        await Infrastructure.Data.Identity.Seeds.DefaultSuperAdminUser.SeedAsync(userManager, roleManager);
                        //await Infrastructure.Identity.Seeds.DefaultBasicUser.SeedAsync(userManager, roleManager);
                        //logger.LogInformation("Finished Seeding Default Data");
                        //logger.LogInformation("Application Starting");
                    }
                    catch (Exception ex)
                    {
                        Log.Fatal(ex, "An error occurred seeding the DB");
                        //logger.LogWarning(ex, "An error occurred seeding the DB");
                    }
                }
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }

            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
