using spacetraders.Models;
using spacetraders.Http;
using Serilog;
using Serilog.Core;

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

        // ----------------------------------------------------------------------------------
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

        // ----------------------------------------------------------------------------------

        public async Task<BaseURLResponse> GetInfo()
        {
            Request req = new(Http.Enum.RequestType.GET, $"", "");
            return await pool.AddRequest<BaseURLResponse>(req);
        }

        public async Task<Agent> GetAgent()
        {
            Request req = new(Http.Enum.RequestType.GET, $"my/agent", "");
            return await pool.AddRequest<Agent>(req);
        }

        public async Task<Models.System[]> GetSystems(int limit, int page)
        {
            Request req = new(spacetraders.Http.Enum.RequestType.GET, $"systems?page={page}&limit={limit}", "");
            return await pool.AddRequest<Models.System[]>(req);
        }



        public async Task<Waypoint[]> GetWaypointForSystem(Models.System system, int limit, int page)
        {
            Request req = new(Http.Enum.RequestType.GET, $"systems/{system.symbol}/waypoints?page={page}&limit={limit}", "");
            return await pool.AddRequest<Waypoint[]>(req);
        }
    }
}