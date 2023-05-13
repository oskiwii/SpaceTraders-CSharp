
using Newtonsoft.Json;
using spacetraders.Core;
using spacetraders.Enum;
using spacetraders.Http;
using System.Text.Json.Nodes;

namespace spacetraders.Models
{
    public class Contract
    {
        public string id { get; set; }
        public string factionSymbol { get; set; }
        public ContractType type { get; set; }
        public ContractTerms terms { get; set; }
        public bool accepted { get; set; }
        public bool fulfilled { get; set; }
        public DateTime expiration { get; set; }

        public async Task<(Agent, Contract)> AcceptContract()
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/contracts/{id}/accept", "");
            string JSON = await Constants.pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Agent>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Contract>(Root[1].ToJsonString()));
        }


        public async Task<(Contract, ShipCargo)> DeliverContract(string ShipSymbol, string TradeSymbol, Int32 units)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/contracts/{id}/deliver", "{" + $"\"tradeSymbol\": \"{TradeSymbol}\", \"units\": {units}, \"shipSymbol\": \"{ShipSymbol}\"" + "}");
            string JSON = await Constants.pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Contract>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<ShipCargo>(Root[1].ToJsonString()));
        }


        public async Task<(Agent, Contract)> FulfillContract()
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/contracts/{id}/fulfill", "");
            string JSON = await Constants.pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Agent>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Contract>(Root[1].ToJsonString()));
        }
    }
}