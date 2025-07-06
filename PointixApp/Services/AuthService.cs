using PointixApp.DataLayer;
using PointixApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if(UserName == "" || Password == "")
                return new AuthModel() { Message = "Please Enter fill all fiels!"};

            var users = this.context.Users.ToList() ;

            foreach (var user in users)
            {
                if (user.UserName == UserName && user.Password == Password)
                    return new AuthModel() 
                    {
                        IsAuthenticated = true ,
                        Id = user.UserId ,
                        Username = user.UserName ,
                        Name = user.Name ,
                    };
            }

            return new AuthModel() { Message = "UserName or Password is not valid!" };
            
        }
    }
}
