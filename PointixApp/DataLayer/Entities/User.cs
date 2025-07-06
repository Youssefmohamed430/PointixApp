using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.DataLayer.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Sale> Sales { get; set; }
        public List<InventoryLog> inventoryLog { get; set; }
        public List<UserNotification> userNotification { get; set; }

    }
    public enum Roles { admin , staff} // at  data base 1 => admin 
                                       //               0 => staff         
}
