using System.ComponentModel.DataAnnotations;

namespace Clarity.Core.Domain
{
    public class Notification
    {
        public int Id { get; set; }
        [Required]
        public string Sender { get; set; }
        [Required]
        public string Recipient { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime? DateTimeSent { get; set; }
        public int Attempts { get; set; }
        public bool Pending { get; set; }
        public string? SendStatusCode { get; set; }


        public Notification()
        {
            Pending = true;
            Attempts = 0;
            DateTimeCreated = DateTime.Now;
        }
    }
}
