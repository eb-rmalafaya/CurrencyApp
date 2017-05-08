using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Helpers
{
    public static class LoadCurrencies
    {

        static public List<CurrencyRepresentation> CurrenciesAvaiable()
        {
            List<CurrencyRepresentation> currencies = new List<CurrencyRepresentation>();

            currencies.Add(new CurrencyRepresentation("United States Dollar", SymbolEnum.USD));
            currencies.Add(new CurrencyRepresentation("Euro", SymbolEnum.EUR));
            currencies.Add(new CurrencyRepresentation("Japanese Yen", SymbolEnum.JPY));
            currencies.Add(new CurrencyRepresentation("Pound Sterling", SymbolEnum.GBP));
            currencies.Add(new CurrencyRepresentation("Swiss Franc", SymbolEnum.CHF));
            currencies.Add(new CurrencyRepresentation("Chinese Yuan", SymbolEnum.CNY));
            currencies.Add(new CurrencyRepresentation("Swedish Krona", SymbolEnum.SEK));
            currencies.Add(new CurrencyRepresentation("Mexican Peso", SymbolEnum.MXN));
            currencies.Add(new CurrencyRepresentation("Norwegian Krone", SymbolEnum.NOK));
            currencies.Add(new CurrencyRepresentation("South Korean Won", SymbolEnum.KRW));

            return currencies;
        }
    }
}
