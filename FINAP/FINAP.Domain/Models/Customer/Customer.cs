using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAP.Domain.Models.Customer
{
    public class Customer :BaseEntity
    {
        public int numCus_Id { get; set; }
        public string varName{ get; set;}
        public int numPhone{ get; set; }
        public string varAddress { get; set; }
        public string varEmail { get; set; }

    }
}
