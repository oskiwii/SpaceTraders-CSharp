using spacetraders.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class ShipModule
    {
        public ShipModuleSymbol symbol { get; set; }
        public Int32 capacity { get; set; }
        public Int32 range { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public ShipRequirements requirements { get; set; }
    }
}
