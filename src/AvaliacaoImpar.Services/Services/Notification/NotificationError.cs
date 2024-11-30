using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Interfaces.Services.notification;

namespace AvaliacaoImpar.Services.Services.Notification
{
    public class NotificationError : INotificationError
    {

        public IList<string> Notifications { get; private set; }

        public NotificationError()
        {
            this.Notifications = new List<string>();
        }

        public void AddNotification(string message)
        {
             Notifications.Add(message);
        }

        public async Task<IList<string>> GetNotifications()
        {
            return await Task.FromResult(Notifications);
        }

        public async Task<bool> HasNotifications()
        {
            return await Task.FromResult(Notifications.Any());
        }
    }
}
