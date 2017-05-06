using CurrencyApplication.Helpers;
using CurrencyApplication.Models;
using Newtonsoft.Json.Linq;
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
        //private String API_URL_SINGLE = "http://download.finance.yahoo.com/d/quotes?f=sl1d1t1&s=";

        public Double getCurrency()
        {
            return 0;
        }

        public async Task<String> getCurrencies()
        {
            HTTPHandler client = new HTTPHandler();
            return await client.RefreshDataAsync(API_URL_ALL);
        }
    
        public Double Convert(String symbolFrom, String symbolTo, Double qtd, List<CurrencyDTO> list)
        {
            CurrencyDTO from = null;
            CurrencyDTO to = null;
            foreach (CurrencyDTO currency in list)
            {
                if (currency.Symbol != null && currency.Symbol.Length > 0)
                {
                    var symbol = currency.Symbol.Substring(0, currency.Symbol.Length - 2);
                    if (symbol.CompareTo(symbolFrom) == 0)
                    {
                        from = currency;
                        if (to != null) break;
                        continue;
                    }
                    if (symbol.CompareTo(symbolTo) == 0)
                    {
                        to = currency;
                        if (from != null) break;
                        continue;
                    }
                }
            }

            return Convert(to, from, qtd);
        }

        public Double Convert(CurrencyDTO symbolFrom, CurrencyDTO symbolTo, Double qtd)
        {
            return (symbolFrom.Price / symbolTo.Price) * qtd;
        }

        public async Task<List<CurrencyDTO>> GetCurrenciesDTO()
        {
            String response = await getCurrencies();
            List<CurrencyDTO> list = new List<CurrencyDTO>();

            var fdate = JObject.Parse(response)["list"];
            String resources = fdate.ToString();
            JToken resources1 = JObject.Parse(resources)["resources"];

            foreach (JToken item in resources1)
            {
                JToken subItem = item["resource"]["fields"].Value<JToken>();
                //JToken subsubItem = subItem["fields"].Value<JToken>();
                String symbol = subItem["symbol"].Value<String>();
                String name = subItem["name"].Value<String>();
                String ts = subItem["ts"].Value<String>();
                String utctime = subItem["utctime"].Value<String>();
                Double price = subItem["price"].Value<Double>();
                String type = subItem["type"].Value<String>();
                list.Add(new CurrencyDTO(name, type, ts, utctime, price, symbol));
                //JsonListBox.Items.Add(fileName);
            }
            return list;
        }
    }
}
