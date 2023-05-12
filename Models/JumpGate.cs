using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class JumpGate
    {
        public Int32 jumpRange { get; set; }
        public string factionSymbol { get; set; }
        public ConnectedSystem[] connectedSystems { get; set; }
    }
}
