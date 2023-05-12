using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class Market
    {
        public string symbol { get; set; }
        public TradeGood[] exports { get; set; }
        public TradeGood[] imports { get; set; }
        public TradeGood[] exchange { get; set; }
        public MarketTransaction[] transactions { get; set; }
        public MarketTradeGood[] tradeGoods { get; set; }

    }
}
