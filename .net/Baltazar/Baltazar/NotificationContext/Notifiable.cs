using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baltazar.NotificationContext
{
    public abstract class Notifiable
    {
        public Notifiable()
        {
            Notification = new List<Notification>();
        }

        public List<Notification> Notification { get; set; }

        public void AddNotification(Notification notification)
        {
            Notification.Add(notification);
        }

        public void AddNotifications(IEnumerable<Notification> notifications)
        {
            Notification.AddRange(notifications);
        }

        public bool IsInvalid => Notification.Any();
    }
}
