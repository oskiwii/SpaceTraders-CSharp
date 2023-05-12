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

        public async Task<Agent> Refresh()
        {
            string URL = $"{Core.Constants.BaseURL}/my/agent";
            Request req = new(Http.Enum.RequestType.GET, URL, "");
            Agent temp = await Core.Constants.pool.AddRequest<Agent>(req);

            this.credits = temp.credits;
            this.headquarters = temp.headquarters;
            this.accountID = temp.accountID;
            this.symbol = temp.symbol;

            return this;
        }

        public async Task<Ship[]> GetShips(int limit, int page)
        {
            string URL = $"{Core.Constants.BaseURL}/my/ships?page={page}&limit={limit}";
            Request req = new(Http.Enum.RequestType.GET, URL, "");

            return await Core.Constants.pool.AddRequest<Ship[]>(req);
        }

        public async Task GetContracts(int limit, int page)
        {
            string URL = $"{Core.Constants.BaseURL}/my/contracts";
            return;
        }
    }
}
 