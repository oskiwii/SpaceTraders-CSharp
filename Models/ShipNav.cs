using spacetraders.Enum;

namespace spacetraders.Models
{
    public class ShipNav
    {
        public string systemSymbol { get; set; }
        public string waypointSymbol { get; set; }
        public ShipNavRoute route { get; set; }
        public ShipStatus status { get; set; }
        public FlightMode flightMode { get; set; }
    }
}