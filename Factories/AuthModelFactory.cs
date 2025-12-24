using PointixApp.DataLayer;
using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace PointixApp.Factories
{
    public class AuthModelFactory
    {
        public AuthModel CreateAuthModel(string msg,User user)
        {
            if (msg != "")
                return new AuthModel() { Message = msg };
            else
                return new AuthModel()
                {
                    IsAuthenticated = true,
                    Id = user.UserId,
                    Username = user.UserName,
                    Name = user.Name,
                    role = user.Role,
                };
        }
    }
}
