using CTD.BussinessOperations.Models.CustomModels;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTD.BussinessOperations.Services
{
    public interface IEmailSendService
    {
        Task<bool> SendEmailAsync(Message message);
    }
    public class EmailSendService : IEmailSendService
    {
        private readonly EmailConfiguration _emailConfig;
        public EmailSendService(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public async Task<bool> SendEmailAsync(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            return await SendAsync(emailMessage);
        }
        private async Task<bool> SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                    await client.SendAsync(mailMessage);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message.ToString());
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.AddRange(message.From);
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };
            return emailMessage;
        }
    }
}
