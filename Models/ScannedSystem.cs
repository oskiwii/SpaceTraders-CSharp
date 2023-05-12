using spacetraders.Enum;

namespace spacetraders.Models
{
    public class ScannedSystem
    {
        public string symbol { get; set; }
        public string sectorSymbol { get; set; }
        public SystemType type { get; set; }
        public Int32 x { get; set; }
        public Int32 y { get; set; }
        public Int32 distance { get; set; }
    }
}
