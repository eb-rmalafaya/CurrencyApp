using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CurrencyApplication.Models;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PedidoAPITest()
        {
            string json = @"{
	'list': {
		'meta': {
			'type': 'resource-list',
			'start': 0,
			'count': 188
		},
		'resources': [{
				'resource': {
					'classname': 'Quote',
					'fields': {
						'name': 'USD/KRW',
						'price': '1135.489990',
						'symbol': 'KRW=X',
						'ts': '1493641857',
						'type': 'currency',
						'utctime': '2017-05-01T12:30:57+0000',
						'volume': '0'
					}
				}
			},
			{
				'resource': {
					'classname': 'Quote',
					'fields': {
						'name': 'SILVER 1 OZ 999 NY',
						'price': '0.058292',
						'symbol': 'XAG=X',
						'ts': '1493641873',
						'type': 'currency',
						'utctime': '2017-05-01T12:31:13+0000',
						'volume': '36'
					}
				}
			}
		]
	}
}";

            var fdate = JObject.Parse(json)["list"];
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
                   
                //JsonListBox.Items.Add(fileName);
            }


            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task LeituraDeCurrenciesTest()
        {
            CurrencyApplication.API.APIHandler api = new CurrencyApplication.API.APIHandler();
            List<CurrencyDTO> list = await api.GetCurrenciesDTO();
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public async Task ConvertTest()
        {
            CurrencyApplication.API.APIHandler api = new CurrencyApplication.API.APIHandler();
            List<CurrencyDTO> list = await api.GetCurrenciesDTO();
            Double response = api.Convert("EUR", "USD", 1, list);
            Assert.IsTrue(response > 1);
        }

        [TestMethod]
        public async Task ConvertTest2()
        {
            CurrencyApplication.API.APIHandler api = new CurrencyApplication.API.APIHandler();
            List<CurrencyDTO> list = await api.GetCurrenciesDTO();
            Double response = api.Convert("USD", "EUR", 1, list);
            Assert.IsTrue( response < 1);
        }

        [TestMethod]
        public async Task ConvertTest3()
        {
            CurrencyApplication.API.APIHandler api = new CurrencyApplication.API.APIHandler();
            List<CurrencyDTO> list = await api.GetCurrenciesDTO();
            Double response = api.Convert("USD", "EUR", 1, list);
            Assert.IsTrue(response < 1);
        }
    }
}
