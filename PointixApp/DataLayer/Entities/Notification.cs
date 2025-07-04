using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.DataLayer.Entities
{
    public class Notification
    {
        public int NotifId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime NotifDate { get; set; }
        public List<UserNotification> userNotification { get; set; }
    }
}
