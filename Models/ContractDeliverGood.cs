using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class ContractDeliverGood
    {
        public string tradeSymbol { get; set; }
        public string destinationSymbol { get; set; }
        public Int32 unitsRequired { get; set; }
        public Int32 unitsFulfilled { get; set; }
    }
}
