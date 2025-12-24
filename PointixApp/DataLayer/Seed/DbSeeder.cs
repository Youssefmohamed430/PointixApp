using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.DataLayer.Seed
{
    public static class DbSeeder
    {
        public static void SeedAdmin(AppDbContext context)
        {
            if (context.Users.Any())
                return;

            var adminUser = new User
            {
                Name = "Admin",
                UserName = "admin123",
                Password = "Admin@123",
                Role = "admin"
            };

            context.Users.Add(adminUser);
            context.SaveChanges();
        }
        public static void SeedUser(AppDbContext context)
        {
            if (context.Users.Any())
                return;

            var User = new User
            {
                Name = "User",
                UserName = "user123",
                Password = "User@123",
                Role = "user"
            };

            context.Users.Add(User);
            context.SaveChanges();
        }
    }
}
