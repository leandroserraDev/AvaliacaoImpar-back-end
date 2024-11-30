using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoImpar.Domain.Interfaces.Services.notification
{
    public interface INotificationError
    {
        Task<IList<string>> GetNotifications();
        Task<bool> HasNotifications();

        void AddNotification(string message);
    }
}
