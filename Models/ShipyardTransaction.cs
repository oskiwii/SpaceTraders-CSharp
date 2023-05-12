using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class ShipyardTransaction
    {
        public string shipSymbol { get; set; }
        public Int32 price { get; set; }
        public string agentSymbol { get; set; }
        public DateTime timestamp { get; set; }
    }
}
