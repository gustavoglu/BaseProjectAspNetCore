using BaseProjectANC.Domain.Core.Events;
using System;

namespace BaseProjectANC.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {

        public Guid NotificationId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public int Version { get; set; }

        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
            Version = 1;
            NotificationId = Guid.NewGuid();
        }

    }
}
