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
        public MailboxAddress To { get; set; }
        public MailboxAddress From { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Message(EmailNameModel to, string subject, string content, EmailNameModel from)
        {
            To = new (to.FromName, to.FromEmail);
            From = new (from.FromName, from.FromEmail);
            Subject = subject;
            Content = content;
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
