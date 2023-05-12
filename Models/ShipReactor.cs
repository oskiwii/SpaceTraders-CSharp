using spacetraders.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class ShipReactor
    {
        public ReactorSymbol symbol { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Int32 condition { get; set; }
        public Int32 powerOutput { get; set; }
        public ShipRequirements requirements { get; set; }
    }
}
