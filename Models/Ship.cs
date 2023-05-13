using Newtonsoft.Json;
using spacetraders.Core;
using spacetraders.Enum;
using spacetraders.Http;
using System.Text.Json.Nodes;

namespace spacetraders.Models
{
    public class Ship
    {
        public string symbol { get; set; }
        public ShipRegistration registration { get; set; }
        public ShipNav nav { get; set; }
        public ShipCrew crew { get; set; }
        public ShipFrame frame { get; set; }
        public ShipReactor reactor { get; set; }
        public ShipEngine engine { get; set; }
        public ShipModule[] modules { get; set; }
        public ShipMount[] mounts { get; set; }
        public ShipCargo cargo { get; set; }
        public ShipFuel fuel { get; set; }

        public async Task<ShipCargo> GetShipCargo()
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/ships/{symbol}/cargo", "");
            string JSON = await Constants.pool.AddRequest(req);

            return JsonConvert.DeserializeObject<ShipCargo>(JSON);
        }


        public async Task<Nav> OrbitShip()
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{symbol}/orbit", "");
            string JSON = await Constants.pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Nav>(JSON);
        }


        public async Task<Refinement> Refine(TradeSymbol Produce)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{symbol}/refine", string.Format("{\"produce\": \"{}\"}", Produce.ToString()));
            string JSON = await Constants.pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Refinement>(JSON);
        }


        public async Task<(Chart, Waypoint)> CreateChart()
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{symbol}/chart", "");
            string JSON = await Constants.pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Chart>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Waypoint>(Root[1].ToJsonString()));
        }


        public async Task<Cooldown> GetShipCooldown()
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/ships/{symbol}/cooldown", "");
            string JSON = await Constants.pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Cooldown>(JSON);
        }


        public async Task<Nav> DockShip()
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{symbol}/dock", "");
            string JSON = await Constants.pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Nav>(JSON);
        }


        public async Task<(Cooldown, Survey[])> CreateSurvey()
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{symbol}/survey", "");
            string JSON = await Constants.pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Cooldown>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Survey[]>(Root[1].ToJsonString()));
        }


        public async Task<Survey> Extract(Survey survey = null)
        {
            if (survey != null)
            {
                string JSON = JsonConvert.SerializeObject(survey);
                Request req = new(Http.Enum.RequestType.POST, $"my/ships/{symbol}/extract", string.Format("{\"survey\": {}", JSON));
                JSON = await Constants.pool.AddRequest(req);

                return JsonConvert.DeserializeObject<Survey>(JSON);
            }
            else
            {
                Request req = new(Http.Enum.RequestType.POST, $"my/ships/{symbol}/extract", "");
                string JSON = await Constants.pool.AddRequest(req);

                return JsonConvert.DeserializeObject<Survey>(JSON);
            }
        }


        public async Task<ShipCargo> Jettison(string symbol, Int32 units)
        {
            string JSON = $"\"symbol\": \"{symbol}\", \"units\": {units}";
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{symbol}/jettison", "{" + JSON + "}");
            JSON = await Constants.pool.AddRequest(req);

            return JsonConvert.DeserializeObject<ShipCargo>(JSON);
        }


        public async Task<(Cooldown, Nav)> Jump(string SystemSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{symbol}/jump", "{" + $"\"systemSymbol\": \"{SystemSymbol}\"" + "}");
            string JSON = await Constants.pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Cooldown>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Nav>(Root[1].ToJsonString()));
        }


        public async Task<(ShipFuel, Nav)> NavigateTo(string WaypointSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{symbol}/navigate", "{" + $"\"waypointSymbol\": \"{WaypointSymbol}\"" + "}");
            string JSON = await Constants.pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<ShipFuel>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Nav>(Root[1].ToJsonString()));
        }


        public async Task<Nav> UpdateNav(FlightMode FlightMode)
        {
            Request req = new(Http.Enum.RequestType.PUT, $"my/ships/{symbol}/nav", "{" + $"\"flightMode\": \"{FlightMode.ToString()}\"" + "}");
            string JSON = await Constants.pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Nav>(JSON);
        }


        public async Task<Nav> GetNav()
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/ships/{symbol}/nav", "");
            string JSON = await Constants.pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Nav>(JSON);
        }


        public async Task<(ShipFuel, Nav)> Warp(string WaypointSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{symbol}/warp", "{" + $"\"waypointSymbol\": \"{WaypointSymbol}\"" + "}");
            string JSON = await Constants.pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<ShipFuel>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Nav>(Root[1].ToJsonString()));
        }


        public async Task<(Agent, ShipCargo, Transaction)> SellCargo(string CargoSymbol, Int32 units)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{symbol}/sell", "{" + $"\"symbol\": \"{CargoSymbol}\", \"units\": {units}" + "}");
            string JSON = await Constants.pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Agent>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<ShipCargo>(Root[1].ToJsonString()), JsonConvert.DeserializeObject<Transaction>(Root[2].ToJsonString()));
        }


        public async Task<(Cooldown, ScannedSystem[])> ScanSystems()
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{symbol}/scan/systems", "");
            string JSON = await Constants.pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Cooldown>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<ScannedSystem[]>(Root[1].ToJsonString()));
        }


        public async Task<(Cooldown, ScannedWaypoint[])> ScanWaypoints()
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{symbol}/scan/waypoints", "");
            string JSON = await Constants.pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Cooldown>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<ScannedWaypoint[]>(Root[1].ToJsonString()));
        }


        public async Task<(Cooldown, ScannedShip[])> ScanShips()
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{symbol}/scan/ships", "");
            string JSON = await Constants.pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Cooldown>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<ScannedShip[]>(Root[1].ToJsonString()));
        }


        public async Task<(Agent, ShipFuel)> Refuel()
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{symbol}/refuel", "");
            string JSON = await Constants.pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Agent>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<ShipFuel>(Root[1].ToJsonString()));
        }


        public async Task<(Agent, ShipCargo, Transaction)> PurchaseCargo(string CargoSymbol, Int32 units)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{symbol}/purchase", "{" + $"\"symbol\": \"{CargoSymbol}\", \"units\": {units}" + "}");
            string JSON = await Constants.pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Agent>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<ShipCargo>(Root[1].ToJsonString()), JsonConvert.DeserializeObject<Transaction>(Root[2].ToJsonString()));
        }


        public async Task<ShipCargo> TransferCargo(string TradeSymbol, Int32 units, string OtherShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{symbol}/transfer", "{" + $"\"tradeSymbol\": \"{TradeSymbol}\", \"units\": {units}, \"shipSymbol\": \"{OtherShipSymbol}\"" + "}");
            string JSON = await Constants.pool.AddRequest(req);

            return JsonConvert.DeserializeObject<ShipCargo>(JSON);
        }
    }
}