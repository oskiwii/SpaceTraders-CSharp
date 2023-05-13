using Newtonsoft.Json;
using spacetraders.Core;
using spacetraders.Enum;
using spacetraders.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class Shipyard
    {
        public string symbol { get; set; }
        public ShipTypeObject[] shipTypes { get; set; }
        public ShipyardTransaction[] transactions { get; set; }
        public ShipyardShip[] ships { get; set; }

        public async Task<(Agent, Ship, Transaction)> PurchaseShip(ShipType Type)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships", string.Format("{\"shipType\": {}, \"waypointSymbol\": {}}", Type.ToString(), symbol));
            string JSON = await Constants.pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Agent>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Ship>(Root[1].ToJsonString()), JsonConvert.DeserializeObject<Transaction>(Root[2].ToJsonString()));
        }
    }
}
