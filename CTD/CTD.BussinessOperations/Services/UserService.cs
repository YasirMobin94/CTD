using CTD.BussinessOperations.Data;
using CTD.BussinessOperations.Models.CustomModels;
using CTD.BussinessOperations.Models.Entities;
using CTD.BussinessOperations.Models.ViewModels;
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
        private readonly EmailConfiguration _emailConfig;

        public UserService(CTDContext context, IEmailSendService emailSendService, EmailConfiguration emailConfig)
        {
            _context = context;
            _emailSendService = emailSendService;
            _emailConfig = emailConfig;

        }
        public async Task<UserViewModel> SaveUserEmailMessageAsync(UserViewModel userVM)
        {
            try
            {
                var users = _context.UserEmails.ToList();
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


                var emailBody = GetEmailBody(userVM);
                var isUserSentMail = await _emailSendService.SendEmailAsync(
                                        new Message(new EmailNameModel(userVM.Name, userVM.Email), _emailConfig.Subject, emailBody, new EmailNameModel(_emailConfig.FromName, _emailConfig.FromEmail)));
                if (isUserSentMail)
                {
                    var adminMailBody = GetEmailBodyForAdmin(userVM);
                    await _emailSendService.SendEmailAsync(
                                new Message(new EmailNameModel(_emailConfig.FromName, _emailConfig.FromEmail), _emailConfig.Subject, adminMailBody, new EmailNameModel(userVM.Name, userVM.Email)));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex?.Message);
            }
            return userVM;
        }
        private string GetEmailBodyForAdmin(UserViewModel userVM)
        {
            string body = string.Empty;
            body = System.IO.File.ReadAllText(Path.Combine(userVM.FilePath, "AdminEmailMessage.html"));
            body = body.Replace("[UserName]", userVM.Name);
            body = body.Replace("[Message]", userVM.Message);
            body = body.Replace("[CurrentYear]", DateTime.UtcNow.Year + "");

            return body;
        }
        private string GetEmailBody(UserViewModel userVM)
        {
            string body = string.Empty;
            body = System.IO.File.ReadAllText(Path.Combine(userVM.FilePath, "EmailResponse.html"));
            body = body.Replace("[UserName]", userVM.Name);
            body = body.Replace("[CurrentYear]", DateTime.UtcNow.Year + "");

            return body;
        }
    }
}
