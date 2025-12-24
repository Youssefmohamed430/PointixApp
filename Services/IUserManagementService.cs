using PointixApp.DataLayer.Entities;
using PointixApp.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Services
{
    public interface IUserManagementService
    {
        IQueryable<User> GetUsers();
        IQueryable<User> SearchUser(string name);
        Exception AddUser(string username, string name, string password, string role);
        Exception EditUser(int userid, string username, string name, string password, string role);
        Exception RemoveUser(int Userid);
    }
}
