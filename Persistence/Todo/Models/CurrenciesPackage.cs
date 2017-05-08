using System.Collections.Generic;
using SQLite;
using System;
using Todo.Utils;

namespace Todo.Models
{
    public class CurrenciesPackage
    {

        public CurrenciesPackage(List<CurrencyDTO> list)
        {
            Currencies = list;
            RequestTimestamp = Utils.Utils.getCurrentTimestamp();
            RequestTimestampString = Utils.Utils.getCurrentDateString();
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public List<CurrencyDTO> Currencies { get; set; }
        public Int32 RequestTimestamp { get; set; }
        public String RequestTimestampString { get; set; }
    }
}
