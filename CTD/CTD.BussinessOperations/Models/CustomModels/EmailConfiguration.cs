using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTD.BussinessOperations.Models.CustomModels
{
    public class EmailConfiguration
    {
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Subject { get; set; }
        public bool UseSsl { get; set; }
    }
    public class ClientEmailConfiguration : EmailConfiguration
    {
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string AdminName { get; set; }     
        public string AdminEmail { get; set; }     

    }
}
