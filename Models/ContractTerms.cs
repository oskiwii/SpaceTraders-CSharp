using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class ContractTerms
    {
        public DateTime deadline { get; set; }
        public ContractPayment payment { get; set; }
        public ContractDeliverGood deliver { get; set; }
    }
}
