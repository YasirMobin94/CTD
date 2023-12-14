using MimeKit;
using Org.BouncyCastle.Pqc.Crypto.Frodo;
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
        public Message(EmailNameModel to, string subject, string content, EmailNameModel from)
        {
            To = new List<MailboxAddress>();
            From = new List<MailboxAddress>();
            To.Add(new MailboxAddress(to.FromName, to.FromEmail));
            Subject = subject;
            Content = content;
            From.Add(new MailboxAddress(from.FromName, from.FromEmail));
        }
    }
    public struct EmailNameModel
    {
        public EmailNameModel()
        {

        }
        public EmailNameModel(string name, string email)
        {
            FromName = name;
            FromEmail = email;
        }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
    }
}
