using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class ShipFuel
    {
        public Int32 current { get; set; }
        public Int32 capacity { get; set; }
        public FuelConsumed consumed { get; set; }
    }
}
