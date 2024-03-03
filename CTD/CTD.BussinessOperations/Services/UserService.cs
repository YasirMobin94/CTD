using CTD.BussinessOperations.Data;
using CTD.BussinessOperations.Extensions;
using CTD.BussinessOperations.Models.CustomModels;
using CTD.BussinessOperations.Models.Entities;
using CTD.BussinessOperations.Models.ViewModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTD.BussinessOperations.Services
{
    public interface IUserService
    {
        Task<UserViewModel> SaveUserEmailMessageAsync(UserViewModel userVM);
    }
    public class UserService : IUserService
    {
        private readonly CTDContext _context;
        private readonly IEmailSendService _emailSendService;
        private readonly ISmtpService _smtpService;
        private readonly ClientEmailConfiguration _emailConfig;

        public UserService(CTDContext context, IEmailSendService emailSendService, ClientEmailConfiguration emailConfig, ISmtpService smtpService)
        {
            _context = context;
            _emailSendService = emailSendService;
            _emailConfig = emailConfig;
            _smtpService = smtpService;
        }
        public async Task<UserViewModel> SaveUserEmailMessageAsync(UserViewModel userVM)
        {
            try
            {
                await SaveUserAsync(userVM);
                var isUserSentMail = await _emailSendService.SendEmailAsync(
                                         message: new Message(
                                             to: new EmailNameModel(userVM.Name, userVM.Email),
                                             subject: _emailConfig.Subject,
                                             content: GetEmailBody(userVM),
                                             from: new EmailNameModel(_emailConfig.FromName, _emailConfig.FromEmail)),
                                         isSentToAdminFromUser: false);
                if (isUserSentMail)
                {
                    await _emailSendService.SendEmailAsync(
                                message: new Message(
                                                to: new EmailNameModel(_emailConfig.AdminName, _emailConfig.AdminEmail),
                                                subject: $"New Message from {userVM.Name}",
                                                content: GetEmailBodyForAdmin(userVM),
                                                from: new EmailNameModel(_emailConfig.FromName, _emailConfig.FromEmail)),
                                isSentToAdminFromUser: true);
                }
            }
            catch (Exception ex)
            {
                Log.Error(exception: ex, messageTemplate: "User: {0}", userVM.ToJson());
                throw new Exception(ex?.Message);
            }
            return userVM;
        }

        private async Task SaveUserAsync(UserViewModel userVM)
        {
            try
            {
                var dbModel = new UserEmail
                {
                    Name = userVM.Name,
                    Email = userVM.Email,
                    Website = userVM.Website,
                    Phone = userVM.Phone,
                    Message = userVM.Message,
                    CreatedTimestamp = DateTime.UtcNow
                };
                await _context.UserEmails.AddAsync(dbModel);
                await _context.SaveChangesAsync();
                userVM.Id = dbModel.Id;
            }
            catch (Exception ex)
            {
                Log.Error(exception: ex, messageTemplate: "SaveUserAsync: {0}", userVM.ToJson());
            }
        }
        private string GetEmailBodyForAdmin(UserViewModel userVM)
        {
            var body = File.ReadAllText(Path.Combine(userVM.FilePath, "AdminEmailMessage.html"));
            body = body.Replace("[UserName]", userVM.Name);
            body = body.Replace("[Email]", userVM.Email);
            body = body.Replace("[Phone]", userVM.Phone);
            body = body.Replace("[Website]", userVM.Website);
            body = body.Replace("[ServicePlan]", userVM.ServicePlanName);
            body = body.Replace("[Message]", userVM.Message);
            body = body.Replace("[CurrentYear]", DateTime.UtcNow.Year + "");

            return body;
        }
        private string GetEmailBody(UserViewModel userVM)
        {
            var body = File.ReadAllText(Path.Combine(userVM.FilePath, "EmailResponse.html"));
            body = body.Replace("[UserName]", userVM.Name);
            body = body.Replace("[CurrentYear]", DateTime.UtcNow.Year + "");

            return body;
        }
    }
}
