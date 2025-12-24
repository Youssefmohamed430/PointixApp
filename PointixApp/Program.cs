using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PointixApp.Controller;
using PointixApp.DataLayer;
using PointixApp.DataLayer.Seed;
using PointixApp.Services;
using System.IO;
using System.Windows.Forms;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace PointixApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder().Build();


            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.Migrate();
                DbSeeder.SeedAdmin(db);
                DbSeeder.SeedUser(db);
            }


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
                    var config = new ConfigurationBuilder()
                     .AddJsonFile("appsettings.json")
                     .Build();

                    var connectionString = config.GetConnectionString("Constr");

                    services.AddDbContextPool<AppDbContext>(options =>
                        options.UseSqlServer(connectionString,
                        sqlOptions => sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

                    services.AddScoped<IAuthService, AuthService>();
                    services.AddScoped<INotificationService, NotificationService>();
                    services.AddScoped<IInventoryService, InventoryService>();
                    services.AddScoped<IUserManagementService, UserManagementService>();

                    services.AddScoped<LogInForm>();
                });
        }
    }
}
