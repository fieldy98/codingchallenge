using System;
using System.Collections.Generic;
using System.Linq;
using codingchallenge.api.Models;

namespace codingchallenge.api.Data
{
    public class NotificationRepo : INotificationRepo
    {
        private readonly AppDbContext _context;

        public NotificationRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateNotification(Notification note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }
            _context.Notifications.Add(note);
        }

        public IEnumerable<Notification> GetAllNotifications()
        {
            return _context.Notifications.ToList();
        }

        public Notification GetNotificationById(int id)
        {
            return _context.Notifications.FirstOrDefault(n => n.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}