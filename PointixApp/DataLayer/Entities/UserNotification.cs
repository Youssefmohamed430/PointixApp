using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.DataLayer.Entities
{
    public class UserNotification
    {
        public int NotifId { get; set; }
        public int UserId { get; set; }
        public Notification notification { get; set; }
        public User user { get; set; }
    }
}
