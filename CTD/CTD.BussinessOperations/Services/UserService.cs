using CTD.BussinessOperations.Data;
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
        public UserService(CTDContext context)
        {
            _context = context;
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
            }
            catch (Exception)
            {
            }
            return userVM;
        }
    }
}
