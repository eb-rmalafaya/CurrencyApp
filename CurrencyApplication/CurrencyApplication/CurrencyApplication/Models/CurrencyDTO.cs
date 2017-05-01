using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApplication.Models
{
    public class CurrencyDTO
    {
        /* String symbol = subItem["symbol"].Value<String>();
                String name = subItem["name"].Value<String>();
                String ts = subItem["ts"].Value<String>();
                String utctime = subItem["utctime"].Value<String>();
                Double price = subItem["price"].Value<Double>();
                String type = subItem["type"].Value<String>();*/

        public CurrencyDTO(String name, String type, String ts, String utc, Double price, String symbol) {
            this.Name = name;
            this.Timestamp = ts;
            this.UTCTime = utc;
            this.Price = price;
            this.Symbol = symbol;
            this.Type = type;
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
        public String Timestamp { get; set; }
        public String UTCTime { get; set; }
        public Double Price { get; set; }
        public String Symbol { get; set; }
        public String Type { get; set; }

    }
}
