using CurrencyApplication.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApplication.API
{
    public class APIHandler
    {
        private String API_URL_ALL = "https://finance.yahoo.com/webservice/v1/symbols/allcurrencies/quote?format=json";
        private String API_URL_SINGLE = "http://download.finance.yahoo.com/d/quotes?f=sl1d1t1&s=";

        public Double getCurrency()
        {
            return 0;
        }

        public async Task<String> getCurrencies()
        {
            HTTPHandler client = new HTTPHandler();
            return await client.RefreshDataAsync(API_URL_ALL);
        }
    }
}
