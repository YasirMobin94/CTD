using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTD.BussinessOperations.Models.Common
{
    public interface IAuditable
    {
        public DateTime CreatedTimestamp { get; set; }
    }
}
