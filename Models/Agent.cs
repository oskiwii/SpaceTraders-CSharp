using Microsoft.VisualBasic;
using spacetraders.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class Agent
    {
        public string accountID { get; set; }
        public string symbol { get; set; }
        public string headquarters { get; set; }
        public Int32 credits { get; set; }
    }
}
 