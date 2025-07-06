using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.DataLayer
{
    public class AuthModel
    {
        public string Message { get; set; } = string.Empty;
        public bool IsAuthenticated { get; set; } = false;
        public int Id { get; set; } = 0;
        public string Username { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public Roles role { get; set; } = Roles.admin;
    }
}
