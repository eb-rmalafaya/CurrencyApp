using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApplication.Models
{
    class CurrencyDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
        public String Timestamp { get; set; }
        public DateTime UTCTime { get; set; }
        public Double Price { get; set; }
        public String Symbol { get; set; }

    }
}
