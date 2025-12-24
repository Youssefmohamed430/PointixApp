using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using PointixApp.DataLayer;
using PointixApp.DataLayer.Entities;
using PointixApp.Factories;
using PointixApp.Handlers;
using PointixApp.Managers;
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
        public Exception AddUser(string username, string name, string password, string role)
        {
            try
            {
                CheckDataValidty(username, name, password, role);

                if (context.Users.Any(u => u.UserName == username && !u.IsDeleted))
                {
                    if (ManageLanguages.Language == "en")
                        throw new InvalidOperationException("Username already exists");
                    else
                        throw new ArgumentException("اسم المستخدم موجود بالفعل!");
                }

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

        private static void CheckDataValidty(string username, string name, string password, string role)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                if (ManageLanguages.Language == "en")
                    throw new ArgumentException("Username cannot be empty");
                else
                    throw new ArgumentException("من فضلك ادخل اسم المستخدم!");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                if (ManageLanguages.Language == "en")
                    throw new ArgumentException("Name cannot be empty");
                else
                    throw new ArgumentException("من فضلك ادخل الاسم!");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                if (ManageLanguages.Language == "en")
                    throw new ArgumentException("Password cannot be empty");
                else
                    throw new ArgumentException("من فضلك ادخل كلمة السر!");
            }

            if (string.IsNullOrWhiteSpace(role))
            {
                if (ManageLanguages.Language == "en")
                    throw new ArgumentException("Role cannot be empty");
                else
                    throw new ArgumentException("من فضلك ادخل الدور!");
            }
        }

        public Exception EditUser(int userid, string username, string name, string password, string role)
        {
            try
            {
                CheckDataValidty(username, name, password, role);

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
                {
                    if (ManageLanguages.Language == "en")
                        throw new InvalidOperationException("Cannot delete the last user");
                    else
                        throw new ArgumentException("لا يمكن حذف اخر مستخدم!");
                }

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

            if (AppCache.CachedUsers == null)
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
