
using spacetraders.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class ShipCrew
    {
        public Int32 current { get; set; }
        public Int32 required { get; set; }
        public Int32 capacity { get; set; }
        public RotationType rotation { get; set; }
        public Int32 morale { get; set; }
        public Int32 wages { get; set; }
    }
}
