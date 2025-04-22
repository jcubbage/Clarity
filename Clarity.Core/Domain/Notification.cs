using System.ComponentModel.DataAnnotations;

namespace Clarity.Core.Domain
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Sender { get; set; }
        [Required]
        [MaxLength(100)]
        public string Recipient { get; set; }
        [Required]
        [MaxLength(100)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(5000)]
        public string Body { get; set; }
        [Required]
        [Display(Name ="Date/Time Created")]
        public DateTime DateTimeCreated { get; set; }
        [Display(Name = "Date/Time Send")]
        public DateTime? DateTimeSent { get; set; }
        public int Attempts { get; set; }
        public bool Pending { get; set; }
        [Display(Name = "Send Status Code")]
        public string? SendStatusCode { get; set; }


        public Notification()
        {
            Pending = true;
            Attempts = 0;
            DateTimeCreated = DateTime.Now;
        }
    }
}
