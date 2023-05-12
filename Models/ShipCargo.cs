using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class ShipCargo
    {
        public Int32 capacity { get; set; }
        public Int32 units { get; set; }
        public ShipCargoItem[] inventory { get; set; }
    }
}
