using System.Collections.Generic;
using codingchallenge.api.Models;

namespace codingchallenge.api.Data
{
    public interface INotificationRepo
    {
        bool SaveChanges();

        IEnumerable<Notification> GetAllNotifications();
        Notification GetNotificationById(int id);
        void CreateNotification(Notification note);
    }
}