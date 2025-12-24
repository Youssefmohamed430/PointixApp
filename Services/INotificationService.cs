using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Services
{
    public interface INotificationService
    {
        IQueryable<UserNotification> SendNotifications(int Id);
        void MarkAsRead(int notifid, int userid);
        void NotifDecreseProducts(Product product);
        void NotifEndProducts(Product product);
    }
}
