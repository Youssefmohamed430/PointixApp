using PointixApp.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Services
{
    public interface IAuthService
    {
        AuthModel LogIn(string UserName,string Password);
    }
}
