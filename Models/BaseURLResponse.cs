using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class BaseURLResponse
    {
        public string status { get; set; }
        public Information stats { get; set; }
        public Leaderboards leaderboards { get; set; }
    }
}
