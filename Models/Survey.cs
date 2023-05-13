using spacetraders.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Models
{
    public class Survey
    {
        public string signature { get; set; }
        public string symbol { get; set; }
        public SurveyDeposit[] deposits { get; set; }
        public DateTime expiration { get; set; }
        public SurveySize size { get; set; }
    }
}
