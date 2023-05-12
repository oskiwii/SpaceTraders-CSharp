
using spacetraders.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class ConnectedSystem
    {
        public string symbol { get; set; }
        public string sectorSymbol { get; set; }
        public string factionSymbol { get; set; }
        public SystemType type { get; set; }
        public Int32 x { get; set; }
        public Int32 y { get; set; }

        public Int32 distance { get; set; }
    }
}
