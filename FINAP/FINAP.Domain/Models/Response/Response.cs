using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAP.Domain.Models.Response
{
    public class Response
    {
        public bool bitSuccess { get; set; }
        public int numResponseID { get; set; }
        public string varTransactionNo { get; set; }
        public string varResponseMessage { get; set; }
    }
}
