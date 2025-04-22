using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clarity.Core.Data;
using Clarity.Core.Domain;

namespace Clarity.Core.Services
{
    public interface INotificationService
    {
        Task CreateEmail(string sender, string recipient, string subject, string body);
    }

    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _dbContext;

        public NotificationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateEmail(string sender, string recipient, string subject, string body)
        {
            var notification = new Notification
            {
                Sender = sender,
                Recipient = recipient,
                Subject = subject,
                Body = body
            }; 
            _dbContext.Notifications.Add(notification);
            await _dbContext.SaveChangesAsync();
        }
    }
}
