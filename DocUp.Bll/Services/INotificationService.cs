using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocUp.Bll.Models;

namespace DocUp.Bll.Services
{
    public interface INotificationService
    {
        public List<NotificationModel> GetUnreadedNotifications();

        public List<NotificationModel> GetAllNotifications();

        public void ReadNotification(string id);
    }
}
