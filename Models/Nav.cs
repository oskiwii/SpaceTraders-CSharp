using spacetraders.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class Nav
    {
        public string systemSymbol { get; set; }
        public string waypointSymbol { get; set; }
        public ShipNavRoute route { get; set; }
        public ShipStatus status { get; set; }
        public FlightMode flightMode { get; set; }
    }
}
