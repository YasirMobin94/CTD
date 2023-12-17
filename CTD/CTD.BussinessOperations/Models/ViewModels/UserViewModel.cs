using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTD.BussinessOperations.Models.ViewModels
{
    public class IdWithFilePath
    {
        public int Id { get; set; }
        public string FilePath { get; set; }

    }
    public class UserViewModel : IdWithFilePath
    {
        [Required]
        [StringLength(30, ErrorMessage = "Name cannot be longer than 30 characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Email cannot be longer than 30 characters")]
        public string Email { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Phone cannot be longer than 30 characters")]
        public string Phone { get; set; }
        [StringLength(200, ErrorMessage = "Website cannot be longer than 200 characters")]
        public string Website { get; set; }
        [Required]
        public string Message { get; set; }


        public void CleanUserModel(UserViewModel user)
        {
            user.Email = user?.Email?.Trim();
            user.Name = user?.Name?.Trim();
        }
    }

}
