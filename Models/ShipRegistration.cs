using spacetraders.Enum;

namespace spacetraders.Models
{
    public class ShipRegistration
    {
        public string name { get; set; }
        public string factionSymbol { get; set; }
        public ShipRole role { get; set; }
    }
}