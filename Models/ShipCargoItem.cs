﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class ShipCargoItem
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Int32 units { get; set; }
    }
}
