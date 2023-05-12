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
    }
}