using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clarity.Core.Domain
{
    public class Notification
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime? DateTimeSent { get; set; }
        public int Attempts { get; set; }
        public bool Pending { get; set; }


        public Notification()
        {
            Pending = true;
            Attempts = 0;
            DateTimeCreated = DateTime.Now;
        }
    }
}
