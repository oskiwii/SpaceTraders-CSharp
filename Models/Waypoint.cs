using spacetraders.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class Waypoint
    {
        public string symbol { get; set; }
        public WaypointType type { get; set; }
        public string systemSymbol { get; set; }
        public Int32 x { get; set; }
        public Int32 y { get; set; }
        public WaypointOrbital[] orbitals { get; set; }
        public WaypointFaction faction { get; set; }
        public WaypointTrait[] traits { get; set; }
        public Chart chart { get; set; }
    }
}
