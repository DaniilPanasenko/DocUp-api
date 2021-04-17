using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocUp.Bll.Models;

namespace DocUp.Bll.Services.Impl
{
    public class NotificationService : INotificationService
    {
        private readonly NotificationsBus _notificationsBus;

        public NotificationService(NotificationsBus notificationsBus)
        {
            _notificationsBus = notificationsBus;
        }

        public List<NotificationModel> GetAllNotifications()
        {
            return _notificationsBus.GetAllNotifications();
        }

        public List<NotificationModel> GetUnreadedNotifications()
        {
            return _notificationsBus.GetUnreadedNotifications();
        }

        public void ReadNotification(string id)
        {
            _notificationsBus.ReadNotification(id);
        }
    }
}
