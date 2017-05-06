using System.Collections.Generic;
using SQLite;

namespace Todo.Models
{
    public class CurrenciesPackage
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public List<CurrencyDTO> Currencies { get; set; }
        public string RequestTimestamp { get; set; }
    }
}
