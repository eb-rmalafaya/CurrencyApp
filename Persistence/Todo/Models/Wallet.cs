using System.Collections.Generic;
using SQLite;

namespace Todo.Models
{
    public class Wallet
    {
        [PrimaryKey, AutoIncrement]
        public string ID { get; set; }
        public string Symbol { get; set; }
        public double Quantity { get; set; }
    }
}
