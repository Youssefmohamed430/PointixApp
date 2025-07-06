using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PointixApp.Controller;
using PointixApp.DataLayer;
using PointixApp.Services;

namespace PointixApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Create the host (dependency injection container)
            var host = CreateHostBuilder().Build();

            // Resolve Form1 from DI container
            var form = host.Services.GetRequiredService<LogInForm>();

            Application.Run(form);
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    // Read connection string from appsettings.json
                    var connectionString = context.Configuration.GetConnectionString("constr");

                    // Register DbContext
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(connectionString));

                    services.AddScoped<IAuthService, AuthService>();

                    // Register Forms
                    services.AddScoped<LogInForm>();
                });
        }
    }
}