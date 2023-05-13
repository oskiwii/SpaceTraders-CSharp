using spacetraders.Models;
using spacetraders.Http;
using Serilog;
using Serilog.Core;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;
using spacetraders.Enum;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Authentication;
using Serilog.Events;
using System.Text.Json.Nodes;

namespace spacetraders.Core
{
    public static class Constants
    {
        public static Pool pool = new(500, 1000);
        public const string BaseURL = "https://v2.api.spacetraders.io";
        public const string OkStatusString = "SpaceTraders is currently online and available to play";
        public static Logger Log = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Debug)
            .WriteTo.File($"logs/{DateTime.Now.ToString()}-Log.txt", rollingInterval: RollingInterval.Minute)
            .CreateLogger();
    }

    // Represents you!
    public class Client
    {
        Pool pool;

        public Client(string Token, bool FilePath)
        {
            // Get token and set it to env. variable "SPACETRADERS_TOKEN"

            if (FilePath)
            {
                Constants.Log.Debug($"Using file path '{Token}' for token");
                Helpers.Helpers.SetTokenFromFile(Token);
            }
            else
            {
                Constants.Log.Debug($"Not using file path for token");
                Environment.SetEnvironmentVariable("SPACETRADERS_TOKEN", Token);
            }

            Constants.Log.Debug($"Environment variable set: 'SPACETRADERS_TOKEN'");

            pool = Constants.pool;
            Task.Run(async () => await pool.Start());
            Constants.Log.Debug($"Started pool");
        }

        public string _DebugDoRequest(string url, string json)
        {
            Request req = new(Http.Enum.RequestType.GET, $"{url}", json);
            return req.run();
        }

        // Factions ----------------------------------------------------------------------------
        
        public async Task<Faction[]> GetFactions(int limit, int page)
        {
            Request req = new(Http.Enum.RequestType.GET, $"factions?page={page}&limit={limit}", "");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Faction[]>(JSON);
        }

        public async Task<Faction> GetFaction(string FactionSymbol)
        {
            Request req = new(Http.Enum.RequestType.GET, $"factions/{FactionSymbol}", "");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Faction>(JSON);
        }

        // Fleet -------------------------------------------------------------------------------
        
        public async Task<Ship[]> GetShips(int page, int limit)
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/ships?page={page}&limit={limit}", "");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Ship[]>(JSON);
        }


        public async Task<(Agent, Ship, Transaction)> PurchaseShip(ShipType Type, string WaypointSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships", string.Format("{\"shipType\": {}, \"waypointSymbol\": {}}", Type.ToString(), WaypointSymbol));
            string JSON = await pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Agent>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Ship>(Root[1].ToJsonString()), JsonConvert.DeserializeObject<Transaction>(Root[2].ToJsonString()));
        }


        public async Task<Ship> GetShip(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/ships/{ShipSymbol}", "");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Ship>(JSON);
        }

        public async Task<ShipCargo> GetShipCargo(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/ships/{ShipSymbol}/cargo", "");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<ShipCargo>(JSON);
        }


        public async Task<Nav> OrbitShip(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/orbit", "");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Nav>(JSON);
        }


        public async Task<Refinement> Refine(string ShipSymbol, TradeSymbol Produce)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/refine", string.Format("{\"produce\": \"{}\"}", Produce.ToString()));
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Refinement>(JSON);
        }


        public async Task<(Chart, Waypoint)> CreateChart(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/chart", "");
            string JSON = await pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Chart>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Waypoint>(Root[1].ToJsonString()));
        }


        public async Task<Cooldown> GetShipCooldown(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/ships/{ShipSymbol}/cooldown", "");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Cooldown>(JSON);
        }


        public async Task<Nav> DockShip(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/dock", "");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Nav>(JSON);
        }


        public async Task<(Cooldown, Survey[])> CreateSurvey(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/survey", "");
            string JSON = await pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Cooldown>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Survey[]>(Root[1].ToJsonString()));
        }


        public async Task<Survey> Extract(string ShipSymbol, Survey survey = null)
        {
            if (survey != null)
            {
                string JSON = JsonConvert.SerializeObject(survey);
                Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/extract", string.Format("{\"survey\": {}", JSON));
                JSON = await pool.AddRequest(req);

                return JsonConvert.DeserializeObject<Survey>(JSON);
            }
            else
            {
                Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/extract", "");
                string JSON = await pool.AddRequest(req);

                return JsonConvert.DeserializeObject<Survey>(JSON);
            }
        }


        public async Task<ShipCargo> Jettison(string ShipSymbol, string symbol, Int32 units)
        {
            string JSON = $"\"symbol\": \"{symbol}\", \"units\": {units}";
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/jettison", "{" + JSON + "}");
            JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<ShipCargo>(JSON);
        }


        public async Task<(Cooldown, Nav)> Jump(string ShipSymbol, string SystemSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/jump", "{"+ $"\"systemSymbol\": \"{SystemSymbol}\"" + "}");
            string JSON = await pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Cooldown>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Nav>(Root[1].ToJsonString()));
        }


        public async Task<(ShipFuel, Nav)> NavigateTo(string ShipSymbol, string WaypointSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/navigate", "{" + $"\"waypointSymbol\": \"{WaypointSymbol}\"" + "}");
            string JSON = await pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<ShipFuel>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Nav>(Root[1].ToJsonString()));
        }


        public async Task<Nav> UpdateNav(string ShipSymbol, FlightMode FlightMode)
        {
            Request req = new(Http.Enum.RequestType.PUT, $"my/ships/{ShipSymbol}/nav", "{" + $"\"flightMode\": \"{FlightMode.ToString()}\"" + "}");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Nav>(JSON);
        }


        public async Task<Nav> GetNav(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/ships/{ShipSymbol}/nav", "");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Nav>(JSON);
        }


        public async Task<(ShipFuel, Nav)> Warp(string ShipSymbol, string WaypointSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/warp", "{" + $"\"waypointSymbol\": \"{WaypointSymbol}\"" + "}");
            string JSON = await pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<ShipFuel>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Nav>(Root[1].ToJsonString()));
        }


        public async Task<(Agent, ShipCargo, Transaction)> SellCargo(string ShipSymbol, string CargoSymbol, Int32 units)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/sell", "{" + $"\"symbol\": \"{CargoSymbol}\", \"units\": {units}" + "}");
            string JSON = await pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Agent>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<ShipCargo>(Root[1].ToJsonString()), JsonConvert.DeserializeObject<Transaction>(Root[2].ToJsonString()));
        }


        public async Task<(Cooldown, ScannedSystem[])> ScanSystems(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/scan/systems", "");
            string JSON = await pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Cooldown>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<ScannedSystem[]>(Root[1].ToJsonString()));
        }


        public async Task<(Cooldown, ScannedWaypoint[])> ScanWaypoints(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/scan/waypoints", "");
            string JSON = await pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Cooldown>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<ScannedWaypoint[]>(Root[1].ToJsonString()));
        }


        public async Task<(Cooldown, ScannedShip[])> ScanShips(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/scan/ships", "");
            string JSON = await pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Cooldown>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<ScannedShip[]>(Root[1].ToJsonString()));
        }


        public async Task<(Agent, ShipFuel)> Refuel(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/refuel", "");
            string JSON = await pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Agent>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<ShipFuel>(Root[1].ToJsonString()));
        }


        public async Task<(Agent, ShipCargo, Transaction)> PurchaseCargo(string ShipSymbol, string CargoSymbol, Int32 units)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/purchase", "{" + $"\"symbol\": \"{CargoSymbol}\", \"units\": {units}" + "}");
            string JSON = await pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Agent>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<ShipCargo>(Root[1].ToJsonString()), JsonConvert.DeserializeObject<Transaction>(Root[2].ToJsonString()));
        }


        public async Task<ShipCargo> TransferCargo(string ShipSymbol, string TradeSymbol, Int32 units, string OtherShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/transfer", "{" + $"\"tradeSymbol\": \"{TradeSymbol}\", \"units\": {units}, \"shipSymbol\": \"{OtherShipSymbol}\"" + "}");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<ShipCargo>(JSON);
        }

        // Contracts -------------------------------------------------------------------------------
        public async Task<(Contract[], Meta)> GetContracts(Int32 page, Int32 limit)
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/contracts?page={page}&limit={limit}", "");
            string JSON = await pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Contract[]>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Meta>(Root[1].ToJsonString()));
        }


        public async Task<Contract> GetContract(string ContractID)
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/contracts/{ContractID}", "");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Contract>(JSON);
        }


        public async Task<(Agent, Contract)> AcceptContract(string ContractID)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/contracts/{ContractID}/accept", "");
            string JSON = await pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Agent>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Contract>(Root[1].ToJsonString()));
        }


        public async Task<(Contract, ShipCargo)> DeliverContract(string ContractID, string ShipSymbol, string TradeSymbol, Int32 units)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/contracts/{ContractID}/deliver", "{" + $"\"tradeSymbol\": \"{TradeSymbol}\", \"units\": {units}, \"shipSymbol\": \"{ShipSymbol}\"" + "}");
            string JSON = await pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Contract>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<ShipCargo>(Root[1].ToJsonString()));
        }


        public async Task<(Agent, Contract)> FulfillContract(string ContractID)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/contracts/{ContractID}/fulfill", "");
            string JSON = await pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Agent>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Contract>(Root[1].ToJsonString()));
        }

        // Systems -------------------------------------------------------------------------------
        public async Task<(Models.System[], Meta)> GetSystems(Int32 page, Int32 limit)
        {
            Request req = new(Http.Enum.RequestType.GET, $"systems?page={page}&limit={limit}", "");
            string JSON = await pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Models.System[]>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Meta>(Root[1].ToJsonString()));
        }


        public async Task<Models.System> GetSystem(string SystemWaypoint)
        {
            Request req = new(Http.Enum.RequestType.GET, $"systems/{SystemWaypoint}", "");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Models.System>(JSON);
        }


        public async Task<(Waypoint[], Meta)> GetWaypoints(string SystemWaypoint, Int32 page, Int32 limit)
        {
            Request req = new(Http.Enum.RequestType.GET, $"systems/{SystemWaypoint}/waypoints?page={page}&limit={limit}", "");
            string JSON = await pool.AddRequest(req);
            JsonNode Root = JsonNode.Parse(JSON);

            return (JsonConvert.DeserializeObject<Waypoint[]>(Root[0].ToJsonString()), JsonConvert.DeserializeObject<Meta>(Root[1].ToJsonString()));
        }


        public async Task<Waypoint> GetWaypoint(string SystemSymbol, string WaypointSymbol)
        {
            Request req = new(Http.Enum.RequestType.GET, $"systems/{SystemSymbol}/waypoints/{WaypointSymbol}", "");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Waypoint>(JSON);
        }


        public async Task<Market> GetMarket(string SystemSymbol, string WaypointSymbol)
        {
            Request req = new(Http.Enum.RequestType.GET, $"systems/{SystemSymbol}/waypoints/{WaypointSymbol}/market", "");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Market>(JSON);
        }


        public async Task<Shipyard> GetShipyard(string SystemSymbol, string WaypointSymbol)
        {
            Request req = new(Http.Enum.RequestType.GET, $"systems/{SystemSymbol}/waypoints/{WaypointSymbol}/shipyard", "");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Shipyard>(JSON);
        }


        public async Task<JumpGate> GetJumpGate(string SystemSymbol, string WaypointSymbol)
        {
            Request req = new(Http.Enum.RequestType.GET, $"systems/{SystemSymbol}/waypoints/{WaypointSymbol}/jump-gate", "");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<JumpGate>(JSON);
        }
        // Systems -------------------------------------------------------------------------------
        public async Task<Agent> GetAgent()
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/agent", "");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<Agent>(JSON);
        }


        public async Task<BaseURLResponse> GetInfo()
        {
            Request req = new(Http.Enum.RequestType.GET, $"", "");
            string JSON = await pool.AddRequest(req);

            return JsonConvert.DeserializeObject<BaseURLResponse>(JSON);
        } 
    }
}