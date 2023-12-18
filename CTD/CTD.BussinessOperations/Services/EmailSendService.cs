using CTD.BussinessOperations.Extensions;
using CTD.BussinessOperations.Models.CustomModels;
using MailKit.Net.Smtp;
using MimeKit;
using Org.BouncyCastle.Bcpg;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTD.BussinessOperations.Services
{
    public interface IEmailSendService
    {
        Task<bool> SendEmailAsync(Message message, bool isSentToAdminFromUser);
    }
    public class EmailSendService : IEmailSendService
    {
        private readonly ClientEmailConfiguration _clientEmailConfig;
        public EmailSendService(ClientEmailConfiguration clientemailConfig)
        {
            _clientEmailConfig = clientemailConfig;
        }
        public async Task<bool> SendEmailAsync(Message message, bool isSentToAdminFromUser)
        {
            var emailMessage = CreateEmailMessage(message, isSentToAdminFromUser);
            return await SendAsync(emailMessage, isSentToAdminFromUser, message);
        }
        private async Task<bool> SendAsync(MimeMessage mailMessage, bool isSentToAdminFromUser, Message message)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_clientEmailConfig.SmtpServer, _clientEmailConfig.Port, _clientEmailConfig.UseSsl);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_clientEmailConfig.UserName, _clientEmailConfig.Password);
                    await client.SendAsync(mailMessage);
                    return true;
                }
                catch (Exception ex)
                {
                    Log.Error(exception: ex, messageTemplate: "Mail Body: {0}, IsSentToAdmin:{1} ,FromAddress: {2}, ToAddress: {3}", message.Content.ToJson(), isSentToAdminFromUser, message.From.Address.ToJson(), message.To.Address.ToJson());
                    throw new Exception(ex?.Message);
                    //return false;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
        private MimeMessage CreateEmailMessage(Message message, bool isAdmin)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(message.From);
            emailMessage.To.Add(message.To);
            //emailMessage.Bcc.Add(fromMessage);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };
            return emailMessage;
        }
    }
}
