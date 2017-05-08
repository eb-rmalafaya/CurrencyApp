using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Helpers
{
    public class CurrencyRepresentation
    {
        public string Name { get; set; }
        public SymbolEnum Symbol { get; set; }

        public CurrencyRepresentation() { }

        public CurrencyRepresentation(string name, SymbolEnum symbol) {
            this.Name = name;
            this.Symbol = symbol;
        }

        override
        public string ToString()
        {
            return this.Name;
        }
    }
}
