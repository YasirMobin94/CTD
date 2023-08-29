using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTD.BussinessOperations.Models.CustomModels
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public List<MailboxAddress> From { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Message(IEnumerable<string> to, string subject, string content, IEnumerable<string> from)
        {
            To = new List<MailboxAddress>();
            From = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(x, x)));
            Subject = subject;
            Content = content;
            From.AddRange(from.Select(x => new MailboxAddress(x, x)));
        }
    }
}
