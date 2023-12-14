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
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Website { get; set; }
        [Required]
        public string Message { get; set; }
    }

}
