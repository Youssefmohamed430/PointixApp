using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using PointixApp.DataLayer;
using PointixApp.DataLayer.Entities;
using PointixApp.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using User = PointixApp.DataLayer.Entities.User;

namespace PointixApp.Services
{
    internal class UserManagementService : IUserManagementService
    {
        private AppDbContext context;

        public UserManagementService(AppDbContext _context)
        {
            this.context = _context;
        }
        public Exception AddUser(string username,string name,string password,string role)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                    throw new ArgumentException("Username cannot be empty");

                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Name cannot be empty");

                if (string.IsNullOrWhiteSpace(password))
                    throw new ArgumentException("Password cannot be empty");

                if (string.IsNullOrWhiteSpace(role))
                    throw new ArgumentException("Role cannot be empty");

                if (context.Users.Any(u => u.UserName == username && !u.IsDeleted))
                    throw new InvalidOperationException("Username already exists");

                var user = new UserFactory()
                    .CreateUser(username, name, password, role);

                context.Users.Add(user);
                context.SaveChanges();
                AppCache.ClearUserCache();

                return null!;
            }
            catch (Exception ex)
            {
                 ExceptionHandler.ShowError("adding user", ex);
                return ex;
            }
        }
        public Exception EditUser(int userid, string username, string name, string password, string role)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                    throw new ArgumentException("Username cannot be empty");

                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Name cannot be empty");

                if (string.IsNullOrWhiteSpace(password))
                    throw new ArgumentException("Password cannot be empty");

                if (string.IsNullOrWhiteSpace(role))
                    throw new ArgumentException("Role cannot be empty");

                var user = context.Users.FirstOrDefault(x => x.UserId == userid && !x.IsDeleted);

                if (user == null)
                    throw new InvalidOperationException("User not found");

                if (context.Users.Any(u => u.UserName == username && u.UserId != userid && !u.IsDeleted))
                    throw new InvalidOperationException("Username already exists");

                EditData(username, name, password, role, user);

                context.SaveChanges();
                AppCache.ClearUserCache();

                return null!;
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("editing user", ex);
                return null;
            }
        }
        private static void EditData(string username, string name, string password, string role, User user)
        {
            user.Name = name;
            user.UserName = username;
            user.Role = role;
            user.Password = password;
        }
        public IQueryable<User> GetUsers() 
        {
            try
            {
                if (AppCache.CachedUsers == null)
                {
                    AppCache.CachedUsers = context.Users
                        .Where(u => !u.IsDeleted)
                        .AsNoTracking();
                }
                return AppCache.CachedUsers;
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("getting users", ex);
                return null;
            }
        }
        public Exception RemoveUser(int Userid)
        {
            try
            {
                if (Userid <= 0)
                    throw new ArgumentException("Invalid user ID");

                var user = context.Users.FirstOrDefault(x => x.UserId == Userid && !x.IsDeleted);

                if (user == null)
                    throw new InvalidOperationException("User not found");

                var usersCount = context.Users
                    .Count(u => !u.IsDeleted);

                if (usersCount <= 1)
                    throw new InvalidOperationException("Cannot delete the last user");

                user.IsDeleted = true;

                context.SaveChanges();

                AppCache.ClearUserCache();

                return null!;
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("removing user", ex);
                return ex;
            }
        }
        public IQueryable<User> SearchUser(string name)
        {
            IQueryable<User> users = null!;

            if(AppCache.CachedUsers == null)
            {
                users = context.Users
                .Where(u => (u.Name.Contains(name) ||
                u.UserName.Contains(name))
                && u.IsDeleted == false);
            }
            else
            {
                users = AppCache.CachedUsers
                .Where(u => (u.Name.Contains(name) ||
                u.UserName.Contains(name))
                && u.IsDeleted == false);
            }
            return users;
        } 
    }
}
