using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class Cooldown
    {
        public string shipSymbol { get; set; }
        public Int32 totalSeconds { get; set; }
        public Int32 remainingSeconds { get; set; }
        public DateTime expiration { get; set; }
    }
}
