
using spacetraders.Enum;

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
    }
}