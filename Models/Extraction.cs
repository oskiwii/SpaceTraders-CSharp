using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class Extraction
    {
        public string shipSymbol { get; set; }
        public ExtractionYield yield { get; set; }
    }
}
