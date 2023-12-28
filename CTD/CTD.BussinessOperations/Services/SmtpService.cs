using CTD.BussinessOperations.Extensions;
using CTD.BussinessOperations.Models.CustomModels;
using Humanizer;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace CTD.BussinessOperations.Services
{
    public class SmtpMessage
    {
        public MailAddress To { get; set; }
        public MailAddress From { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public SmtpMessage(EmailNameModel to, string subject, string content, EmailNameModel from)
        {
            To = new(to.FromEmail, to.FromName);
            From = new(from.FromEmail, from.FromName);
            Subject = subject;
            Content = content;
        }
    }
    public interface ISmtpService
    {
        Task<bool> SendEmailAsync(SmtpMessage message, bool isSentToAdminFromUser);
    }
    public class SmtpService : ISmtpService
    {
        private readonly ClientEmailConfiguration _emailConfig;
        public SmtpService(ClientEmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public async Task<bool> SendEmailAsync(SmtpMessage mailObj, bool isSentToAdminFromUser)
        {
            var smtp = new SmtpClient();
            try
            {
                var body = mailObj.Content;
                var message = new MailMessage()
                {
                    From = mailObj.From,
                    Subject = mailObj.Subject,
                    Body = mailObj.Content,
                    IsBodyHtml = true,
                    Sender = new MailAddress(mailObj.From.Address, mailObj.From.DisplayName)

                };
                message.To.Add(mailObj.To);

                smtp.Host = _emailConfig.SmtpServer;
                smtp.Port = _emailConfig.Port;
                smtp.EnableSsl = _emailConfig.UseSsl;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_emailConfig.UserName, _emailConfig.Password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                await smtp.SendMailAsync(message);

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(exception: ex, messageTemplate: "Mail Content: {0}, IsSentToAdmin:{1} ,FromAddress: {2}, ToAddress: {3}", mailObj.ToJson(), isSentToAdminFromUser, mailObj.From.ToJson(), mailObj.To.ToJson());
                return false;
            }
            finally
            {
                smtp?.Dispose();
            }
        }
    }
}
