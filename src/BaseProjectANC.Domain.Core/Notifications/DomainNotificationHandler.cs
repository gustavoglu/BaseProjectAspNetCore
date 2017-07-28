using System.Collections.Generic;
using System.Linq;

namespace BaseProjectANC.Domain.Core.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler<DomainNotification>
    {
        public List<DomainNotification> Notifications;

        public DomainNotificationHandler()
        {
            Notifications = new List<DomainNotification>();
        }

        public List<DomainNotification> GetNotifications()
        {
            return Notifications;
        }

        public void Handler(DomainNotification message)
        {
            this.Notifications.Add(message);
        }

        public bool HasNotification()
        {
            return GetNotifications().Any();

        }

        public void Dispose()
        {
            Notifications = new List<DomainNotification>();
        }
    }
}
