using spacetraders.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class ShipFrame
    {
        public FrameSymbol symbol { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Int32 condition { get; set; }
        public Int32 moduleSlots { get; set; }
        public Int32 mountingPoints { get; set; }
        public Int32 fuelCapacity { get; set; }
        public ShipRequirements requirements { get; set; }
    }
}
