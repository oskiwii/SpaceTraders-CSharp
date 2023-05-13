using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class Refinement
    {
        public ShipCargo cargo { get; set; }
        public Cooldown cooldown { get; set; }
        public Ingredient[] produced { get; set; }
        public Ingredient[] consumed { get; set; }
    }
}
