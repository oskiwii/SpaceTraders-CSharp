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

namespace spacetraders.Core
{
    public static class Constants
    {
        public static Pool pool = new(500, 1000);
        public const string BaseURL = "https://v2.api.spacetraders.io";
        public const string OkStatusString = "SpaceTraders is currently online and available to play";
        public static Logger Log = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
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
            return await pool.AddRequest<Faction[]>(req);
        }

        public async Task<Faction> GetFaction(string FactionSymbol)
        {
            Request req = new(Http.Enum.RequestType.GET, $"factions/{FactionSymbol}", "");
            return await pool.AddRequest<Faction>(req);
        }

        // Fleet -------------------------------------------------------------------------------
        
        public async Task<Ship[]> GetShips(int page, int limit)
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/ships?page={page}&limit={limit}", "");
            return await pool.AddRequest<Ship[]>(req);
        }


        public async Task<Ship[]> PurchaseShip(ShipType Type, string WaypointSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships", string.Format("{\"shipType\": {}, \"waypointSymbol\": {}}", Type.ToString(), WaypointSymbol));
            return await pool.AddRequest<Ship[]>(req);
        }


        public async Task<Ship> GetShip(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/ships/{ShipSymbol}", "");
            return await pool.AddRequest<Ship>(req);
        }

        public async Task<ShipCargo> GetShipCargo(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/ships/{ShipSymbol}/cargo", "");
            return await pool.AddRequest<ShipCargo>(req);
        }


        public async Task<Nav> OrbitShip(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/orbit", "");
            return await pool.AddRequest<Nav>(req);
        }


        public async Task<Refinement> Refine(string ShipSymbol, TradeSymbol Produce)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/refine", string.Format("{\"produce\": \"{}\"}", Produce.ToString()));
            return await pool.AddRequest<Refinement>(req);
        }


        public async Task<(Chart, Waypoint)> CreateChart(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/chart", "");
            return await pool.AddRequest<(Chart, Waypoint)>(req);
        }


        public async Task<Cooldown> GetShipCooldown(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/ships/{ShipSymbol}/cooldown", "");
            return await pool.AddRequest<Cooldown>(req);
        }


        public async Task<Nav> DockShip(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/dock", "");
            return await pool.AddRequest<Nav>(req);
        }


        public async Task<(Cooldown, Survey[])> CreateSurvey(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/survey", "");
            return await pool.AddRequest<(Cooldown, Survey[])>(req);
        }


        public async Task<Survey> Extract(string ShipSymbol, Survey survey = null)
        {
            if (survey != null)
            {
                string JSON = JsonConvert.SerializeObject(survey);
                Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/extract", string.Format("{\"survey\": {}", JSON));
                return await pool.AddRequest<Survey>(req);
            }
            else
            {
                Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/extract", "");
                return await pool.AddRequest<Survey>(req);
            }
        }


        public async Task<ShipCargo> Jettison(string ShipSymbol, string symbol, Int32 units)
        {
            string JSON = $"\"symbol\": \"{symbol}\", \"units\": {units}";
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/jettison", "{" + JSON + "}");
            return await pool.AddRequest<ShipCargo>(req);
        }


        public async Task<(Cooldown, Nav)> Jump(string ShipSymbol, string SystemSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/jump", "{"+ $"\"systemSymbol\": \"{SystemSymbol}\"" + "}");
            return await pool.AddRequest<(Cooldown, Nav)>(req);
        }


        public async Task<(ShipFuel, Nav)> NavigateTo(string ShipSymbol, string WaypointSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/navigate", "{" + $"\"waypointSymbol\": \"{WaypointSymbol}\"" + "}");
            return await pool.AddRequest<(ShipFuel, Nav)>(req);
        }


        public async Task<Nav> UpdateNav(string ShipSymbol, FlightMode FlightMode)
        {
            Request req = new(Http.Enum.RequestType.PUT, $"my/ships/{ShipSymbol}/nav", "{" + $"\"flightMode\": \"{FlightMode.ToString()}\"" + "}");
            return await pool.AddRequest<Nav>(req);
        }


        public async Task<Nav> GetNav(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/ships/{ShipSymbol}/nav", "");
            return await pool.AddRequest<Nav>(req);
        }


        public async Task<(ShipFuel, Nav)> Warp(string ShipSymbol, string WaypointSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/warp", "{" + $"\"waypointSymbol\": \"{WaypointSymbol}\"" + "}");
            return await pool.AddRequest<(ShipFuel, Nav)>(req);
        }


        public async Task<(Agent, ShipCargo, Transaction)> SellCargo(string ShipSymbol, string CargoSymbol, Int32 units)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/sell", "{" + $"\"symbol\": \"{CargoSymbol}\", \"units\": {units}" + "}");
            return await pool.AddRequest<(Agent, ShipCargo, Transaction)>(req);
        }


        public async Task<(Cooldown, ScannedSystem[])> ScanSystems(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/scan/systems", "");
            return await pool.AddRequest<(Cooldown, ScannedSystem[])>(req);
        }


        public async Task<(Cooldown, ScannedWaypoint[])> ScanWaypoints(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/scan/waypoints", "");
            return await pool.AddRequest<(Cooldown, ScannedWaypoint[])>(req);
        }


        public async Task<(Cooldown, ScannedShip[])> ScanShips(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/scan/ships", "");
            return await pool.AddRequest<(Cooldown, ScannedShip[])>(req);
        }


        public async Task<(Agent, ShipFuel)> Refuel(string ShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/refuel", "");
            return await pool.AddRequest<(Agent, ShipFuel)>(req);
        }


        public async Task<(Agent, ShipCargo, Transaction)> PurchaseCargo(string ShipSymbol, string CargoSymbol, Int32 units)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/purchase", "{" + $"\"symbol\": \"{CargoSymbol}\", \"units\": {units}" + "}");
            return await pool.AddRequest<(Agent, ShipCargo, Transaction)>(req);
        }


        public async Task<ShipCargo> TransferCargo(string ShipSymbol, string TradeSymbol, Int32 units, string OtherShipSymbol)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/ships/{ShipSymbol}/transfer", "{" + $"\"tradeSymbol\": \"{TradeSymbol}\", \"units\": {units}, \"shipSymbol\": \"{OtherShipSymbol}\"" + "}");
            return await pool.AddRequest<ShipCargo>(req);
        }

        // Contracts -------------------------------------------------------------------------------
        public async Task<(Contract[], Meta)> GetContracts(Int32 page, Int32 limit)
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/contracts?page={page}&limit={limit}", "");
            return await pool.AddRequest < (Contract[], Meta)>(req);
        }


        public async Task<Contract> GetContract(string ContractID)
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/contracts/{ContractID}", "");
            return await pool.AddRequest<Contract>(req);
        }


        public async Task<(Agent, Contract)> AcceptContract(string ContractID)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/contracts/{ContractID}/accept", "");
            return await pool.AddRequest<(Agent, Contract)>(req);
        }


        public async Task<(Contract, ShipCargo)> DeliverContract(string ContractID, string ShipSymbol, string TradeSymbol, Int32 units)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/contracts/{ContractID}/deliver", "{" + $"\"tradeSymbol\": \"{TradeSymbol}\", \"units\": {units}, \"shipSymbol\": \"{ShipSymbol}\"" + "}");
            return await pool.AddRequest<(Contract, ShipCargo)>(req);
        }


        public async Task<(Agent, Contract)> FulfillContract(string ContractID)
        {
            Request req = new(Http.Enum.RequestType.POST, $"my/contracts/{ContractID}/fulfill", "");
            return await pool.AddRequest<(Agent, Contract)>(req);
        }

        // Systems -------------------------------------------------------------------------------
        public async Task<(Models.System[], Meta)> GetSystems(Int32 page, Int32 limit)
        {
            Request req = new(Http.Enum.RequestType.GET, $"systems?page={page}&limit={limit}", "");
            return await pool.AddRequest<(Models.System[], Meta)>(req);
        }


        public async Task<Models.System> GetSystem(string SystemWaypoint)
        {
            Request req = new(Http.Enum.RequestType.GET, $"systems/{SystemWaypoint}", "");
            return await pool.AddRequest<Models.System>(req);
        }


        public async Task<(Waypoint[], Meta)> GetWaypoints(string SystemWaypoint, Int32 page, Int32 limit)
        {
            Request req = new(Http.Enum.RequestType.GET, $"systems/{SystemWaypoint}/waypoints?page={page}&limit={limit}", "");
            return await pool.AddRequest <(Waypoint[], Meta)>(req);
        }


        public async Task<Waypoint> GetWaypoint(string SystemSymbol, string WaypointSymbol)
        {
            Request req = new(Http.Enum.RequestType.GET, $"systems/{SystemSymbol}/waypoints/{WaypointSymbol}", "");
            return await pool.AddRequest<Waypoint>(req);
        }


        public async Task<Market> GetMarket(string SystemSymbol, string WaypointSymbol)
        {
            Request req = new(Http.Enum.RequestType.GET, $"systems/{SystemSymbol}/waypoints/{WaypointSymbol}/market", "");
            return await pool.AddRequest<Market>(req);
        }


        public async Task<Shipyard> GetShipyard(string SystemSymbol, string WaypointSymbol)
        {
            Request req = new(Http.Enum.RequestType.GET, $"systems/{SystemSymbol}/waypoints/{WaypointSymbol}/shipyard", "");
            return await pool.AddRequest<Shipyard>(req);
        }


        public async Task<JumpGate> GetJumpGate(string SystemSymbol, string WaypointSymbol)
        {
            Request req = new(Http.Enum.RequestType.GET, $"systems/{SystemSymbol}/waypoints/{WaypointSymbol}/jump-gate", "");
            return await pool.AddRequest<JumpGate>(req);
        }
        // Systems -------------------------------------------------------------------------------
        public async Task<Agent> GetAgent()
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/agent", "");
            return await pool.AddRequest<Agent>(req);
        }


        public async Task<BaseURLResponse> GetInfo()
        {
            Request req = new(Http.Enum.RequestType.GET, $"", "");
            return await pool.AddRequest<BaseURLResponse>(req);
        } 
    }
}