using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class ScannedShip
    {
        public string symbol { get; set; }
        public ShipRegistration registration { get; set; }
        public ShipNav nav { get; set; }
        public ScannedShipFrame frame { get; set; }
        public ScannedShipReactor reactor { get; set; }
        public ScannedShipEngine engine { get; set; }
        public ScannedShipMount[] mounts { get; set; }
    }
}
