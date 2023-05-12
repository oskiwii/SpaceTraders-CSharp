using spacetraders.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class ShipyardShip
    {
        public ShipType type { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Int32 purchasePrice { get; set; }
        public ShipFrame frame { get; set; }
        public ShipReactor reactor { get; set; }
        public ShipEngine engine { get; set; }
        public ShipModule[] modules { get; set; }
        public ShipMount[] mounts { get; set; }
    }
}
