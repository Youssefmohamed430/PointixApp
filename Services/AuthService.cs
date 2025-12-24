using Microsoft.EntityFrameworkCore;
using PointixApp.DataLayer;
using PointixApp.DataLayer.Entities;
using PointixApp.Factories;
using PointixApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PointixApp.Controller
{
    public class AuthService : IAuthService
    {
        private AppDbContext context;

        public AuthService(AppDbContext _context)
        {
            this.context = _context;
        }

        public AuthModel LogIn(string UserName , string Password)
        {
            if (UserName == "" || Password == "")
                return new AuthModelFactory().CreateAuthModel("Please Enter fill all fiels!", null);

            var users = this.context.Users.AsNoTracking().Where(u => !u.IsDeleted);

            return CheckUser(UserName, Password, users);
        }

        private static AuthModel CheckUser(string UserName, string Password, IQueryable<User> users)
        {
            foreach (var user in users)
            {
                if (user.UserName == UserName && user.Password == Password)
                    return new AuthModelFactory().CreateAuthModel("",user);
            }
            return new AuthModelFactory().CreateAuthModel("UserName or Password are not valid!", null);
        }
    }
}
