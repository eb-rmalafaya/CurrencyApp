using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Models;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace Todo.API
{
    public class APIHandler
    {
        private String API_URL_ALL = "https://finance.yahoo.com/webservice/v1/symbols/allcurrencies/quote?format=json";
        //private String API_URL_SINGLE = "http://download.finance.yahoo.com/d/quotes?f=sl1d1t1&s=";

        public IAsyncResult GetAllCurrencies(AsyncCallback callback)
        {
            HTTPHandler client = new HTTPHandler();
            if(callback ==null) return client.Get(API_URL_ALL, null);
            var cb = new AsyncCallback(callback);
            return client.Get(API_URL_ALL, cb);
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

        public String GetAllCurrenciesSync()
        {
            IAsyncResult ar = GetAllCurrencies(null);
            var state = (Tuple<WebRequest>)ar.AsyncState;
            var request = state.Item1;

            using (HttpWebResponse response = request.EndGetResponse(ar) as HttpWebResponse)
            {
                //Device.BeginInvokeOnMainThread(() => state.Item1.Text = "Status: " + response.StatusCode);
                if (response.StatusCode == HttpStatusCode.OK)
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string content = reader.ReadToEnd();
                        return content;
                        //Device.BeginInvokeOnMainThread(() => state.Item2.Text = content);
                    }
            }
            return null;
        }

        public Double Convert(CurrencyDTO symbolFrom, CurrencyDTO symbolTo, Double qtd)
        {
            return (symbolFrom.Price / symbolTo.Price) * qtd;
        }

        public CurrenciesPackage GetCurrenciesPackage()
        {
            List<CurrencyDTO> list = GetCurrenciesDTO();
            return new CurrenciesPackage(list);
        }

        public List<CurrencyDTO> GetCurrenciesDTO()
        {
            String response = GetAllCurrenciesSync();
            List<CurrencyDTO> list = new List<CurrencyDTO>();

            var fdate = JObject.Parse(response)["list"];
            String resources = fdate.ToString();
            JToken resources1 = JObject.Parse(resources)["resources"];

            foreach (JToken item in resources1)
            {
                JToken subItem = item["resource"]["fields"].Value<JToken>();
                String symbol = subItem["symbol"].Value<String>();
                String name = subItem["name"].Value<String>();
                String ts = subItem["ts"].Value<String>();
                String utctime = subItem["utctime"].Value<String>();
                Double price = subItem["price"].Value<Double>();
                String type = subItem["type"].Value<String>();
                list.Add(new CurrencyDTO(name, type, ts, utctime, price, symbol));
            }
            return list;
        }

        private void CallHandler(IAsyncResult ar)
        {
            var state = (Tuple<WebRequest>)ar.AsyncState;
            var request = state.Item1;

            using (HttpWebResponse response = request.EndGetResponse(ar) as HttpWebResponse)
            {
                //Device.BeginInvokeOnMainThread(() => state.Item1.Text = "Status: " + response.StatusCode);
                if (response.StatusCode == HttpStatusCode.OK)
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string content = reader.ReadToEnd();
                        //Device.BeginInvokeOnMainThread(() => state.Item2.Text = content);
                    }
            }
        }
    }
}
