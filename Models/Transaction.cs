using spacetraders.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class Transaction
    {
        public string waypointSymbol { get; set; }
        public string shipSymbol { get; set; }
        public string tradeSymbol { get; set; }
        public TransactionType type { get; set; }
        public Int32 units { get; set; }
        public Int32 pricePerUnit { get; set; }
        public Int32 totalPrice { get; set; }
        public DateTime timestamp { get; set; }
    }
}
