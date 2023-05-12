
using spacetraders.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class MarketTradeGood
    {
        public string symbol { get; set; }
        public Int32 tradeVolume { get; set; }
        public TradeGoodSupply supply { get; set; }
        public Int32 purchasePrice { get; set; }
        public Int32 sellPrice { get; set; }
    }
}
