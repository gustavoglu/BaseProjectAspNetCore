using BaseProjectANC.Domain.Core.Events;
using System.Collections.Generic;

namespace BaseProjectANC.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T>  : IHandler<T> where T : Message
    {
        bool HasNotification();
        List<T> GetNotifications();
    }
}
