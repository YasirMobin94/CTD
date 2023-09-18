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
                await _emailSendService.SendEmailAsync(new Message(new string[] { userVM.Email }, "CTD Support", emailBody, new string[] { _emailConfig.From }));
            }
            catch (Exception)
            {
            }
            return userVM;
        }
        private string GetEmailBody(UserViewModel userVM)
        {
            string body = string.Empty;
            body = System.IO.File.ReadAllText(userVM.FilePath);
            body = body.Replace("[UserName]", userVM.Name);
            body = body.Replace("[CurrentYear]", DateTime.UtcNow.Year + "");

            return body;

        }
    }
}
