using SQLite;
using System.Collections.Generic;

namespace CurrencyApplication.Models
{
    public class CurrenciesPackage
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public List<CurrencyDTO> Currencies { get; set; }
        public string RequestTimestamp { get; set; }


    }
}
