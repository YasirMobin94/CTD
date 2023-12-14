using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTD.BussinessOperations.Models.ViewModels
{
    public record ResponseModel
    {
        public ResponseModel()
        {
            Error = "";
            Success = true;
        }
        public string Error { get; set; }
        public bool Success { get; set; }
        public dynamic Message{ get; set; }
    }
}
