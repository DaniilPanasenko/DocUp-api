using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using DocUp.Bll.Models;

namespace DocUp.Bll
{
    public class NotificationsBus
    {
        public DateTimeOffset LastChecking { get; }

        private ConcurrentDictionary<string, NotificationModel> _notifications =
            new ConcurrentDictionary<string, NotificationModel>();

        public NotificationsBus()
        {
            LastChecking = DateTimeOffset.MinValue;
        }

        public void AddNotification(NotificationModel notification)
        {
            _notifications.TryAdd(notification.Id, notification);
        }

        public bool HasRecipientNotificationDueTime(string phone, int patientId, DateTimeOffset time)
        {
            foreach(var notification in _notifications)
            {
                if (notification.Value.Phone == phone &&
                    notification.Value.Patient.Id == patientId &&
                    notification.Value.DateTime > time)
                {
                    return true;
                }
            }
            return false;
        }

        public void ReadNotification(string id)
        {
            if (_notifications.ContainsKey(id))
            {
                _notifications[id].Processed = true;
            }
        }

        public List<NotificationModel> GetUnreadedNotifications()
        {
            return _notifications
                .Where(x => !x.Value.Processed)
                .Select(x => x.Value)
                .OrderBy(x => x.DateTime)
                .ToList();
        }

        public List<NotificationModel> GetAllNotifications()
        {
            return _notifications
                .Select(x => x.Value)
                .OrderByDescending(x => x.DateTime)
                .ToList();
        }
    }
}
