using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class Shipyard
    {
        public string symbol { get; set; }
        public ShipTypeObject[] shipTypes { get; set; }
        public ShipyardTransaction[] transactions { get; set; }
        public ShipyardShip[] ships { get; set; }
    }
}
