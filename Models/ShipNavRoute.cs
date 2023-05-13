using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class ShipNavRoute
    {
        public Destination destination { get; set; }
        public Destination departure { get; set; }
        public DateTime arrival { get; set; }
        public DateTime departureTime { get; set; }  // May not be included
    }
}
