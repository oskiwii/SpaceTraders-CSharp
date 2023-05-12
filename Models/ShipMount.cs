using spacetraders.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class ShipMount
    {
        public MountSymbol symbol { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Int32 strength { get; set; }
        public DepositType[] deposits { get; set; }
        public ShipRequirements requirements { get; set; }
    }
}
