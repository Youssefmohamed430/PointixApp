using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic.Logging;
using PointixApp.Controller;
using PointixApp.DataLayer;
using PointixApp.Services;

namespace PointixApp
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder().Build();

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
                    services.AddDbContextPool<AppDbContext>(options =>
                        options.UseSqlServer(connectionString, 
                        options => options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));


                    services.AddScoped<IAuthService, AuthService>();
                    services.AddScoped<INotificationService, NotificationService>();
                    services.AddScoped<IInventoryService, InventoryService>();
                    services.AddScoped<IUserManagementService, UserManagementService>();

                    // Register Forms
                    services.AddScoped<LogInForm>();
                });
        }
    }
}
