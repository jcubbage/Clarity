using System.Net.Mail;
using Clarity.Core.Data;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Clarity.Core.Services
{
    public interface IEmailService
    {
        Task SendPendingNotifications(string key);
    }

    public class EmailService : IEmailService
    {
        private readonly ApplicationDbContext _context;
        private SmtpClient _smtpClient;

        public EmailService(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public async Task SendPendingNotifications(string key)
        {
            var client = new SendGridClient(key);
       
            var notices = await _context.Notifications.Where(x => x.Pending).ToListAsync();
            foreach (var notice in notices) 
            {
                if(notice.Attempts >= 3)
                {
                    notice.Pending = false;
                    notice.SendStatusCode = "Max attempts reached. Not sent";
                    continue;
                }
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress(notice.Sender),
                    Subject = notice.Subject,
                    PlainTextContent = notice.Body
                };
                msg.AddTo(new EmailAddress(notice.Recipient));
                var response = await client.SendEmailAsync(msg);

                notice.SendStatusCode = response.StatusCode.ToString();
                notice.Attempts += 1;

                if (response.IsSuccessStatusCode)
                {
                    notice.Pending = false;
                    notice.DateTimeSent = DateTime.UtcNow;                   
                }                           
            }
            await _context.SaveChangesAsync();
        }
    }
}
