using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Factories
{
    internal class UserFactory
    {
        public User CreateUser(string Name,string username,string password,string role)
        => new User()
        {
            Name = Name,
            UserName = username,
            Password = password,
            Role = role
        };
    }
}
