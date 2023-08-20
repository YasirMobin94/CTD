using CTD.BussinessOperations.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CTD.BussinessOperations.Models.Entities
{
    public class UserEmail : IAuditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Message { get; set; }
        public DateTime CreatedTimestamp { get; set; }
    }
}
