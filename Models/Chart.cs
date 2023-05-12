using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class Chart
    {
        public string waypointSymbol { get; set; }
        public string submittedBy { get; set; }
        public DateTime submittedOn { get; set; }
    }
}
