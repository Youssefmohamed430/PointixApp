using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PointixApp.DataLayer;
using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Services
{
    public class NotificationService : INotificationService
    {
        private readonly AppDbContext _appDbContext;
        public NotificationService(AppDbContext context) 
        {
            this._appDbContext = context; 
        }

        public void NotifDecreseProducts(Product product)
        {
            Notification notification = new Notification()
            {
                Message = $"Product : {product.ProductName} Exceed the Minimum quantity",
                NotifDate = DateTime.Now,
                Type = "Warning"
            };


            _appDbContext.Notifications.Add(notification);

            _appDbContext.SaveChanges();

            var notif = _appDbContext.Notifications
                .FirstOrDefault(x => x.NotifDate == notification.NotifDate);

            foreach (var item in _appDbContext.Users.Where(u => !u.IsDeleted))
            {
                UserNotification userNotification = new UserNotification()
                {
                    NotifId = notif.NotifId,
                    UserId = item.UserId,
                };
                _appDbContext.UserNotifications.Add(userNotification);
            }
            _appDbContext.SaveChanges();

            AppCache.ClearNotifcationCache();
        }

        public void NotifEndProducts(Product product)
        {
            Notification notification = new Notification()
            {
                Message = $"Product : {product.ProductName} Is ended",
                NotifDate = DateTime.Now,
                Type = "Problem"
            };

            _appDbContext.Notifications.Add(notification);

            _appDbContext.SaveChanges();

            foreach (var item in _appDbContext.Users.Where(u => !u.IsDeleted))
            {
                UserNotification userNotification = new UserNotification()
                {
                    NotifId = notification.NotifId,
                    UserId = item.UserId,
                };
                _appDbContext.UserNotifications.Add(userNotification);
            }
            _appDbContext.SaveChanges();

            AppCache.ClearNotifcationCache();
        }

        public IQueryable<UserNotification> SendNotifications(int Id)
        {
            if(AppCache.CachedNotifications == null)
            {
                AppCache.CachedNotifications = _appDbContext.UserNotifications
                               .Include(x => x.notification)
                               .Where(x => x.UserId == Id && x.IsRead == false);
            }

            return AppCache.CachedNotifications;
        }

        public void MarkAsRead(int notifid,int userid)
        {
            var notif = _appDbContext.UserNotifications
                                     .Include(n => n.notification)
                                     .FirstOrDefault(n => n.NotifId == notifid && n.UserId == userid);

            notif.IsRead = true;

            _appDbContext.UserNotifications.Update(notif);

            _appDbContext.SaveChanges();
        }
    }
}
