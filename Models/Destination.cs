using spacetraders.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class Destination
    {
        public string symbol { get; set; }
        public WaypointType type { get; set; }
        public string systemSymbol { get; set; }
        public Int32 x { get; set; }
        public Int32 y { get; set; }
    }
}
