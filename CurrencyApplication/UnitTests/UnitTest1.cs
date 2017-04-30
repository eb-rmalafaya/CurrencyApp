using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PedidoAPI()
        {
            Console.WriteLine(">> LeituraDeCurrencies");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task LeituraDeCurrencies()
        {
            Console.WriteLine(">> LeituraDeCurrencies");
            CurrencyApplication.API.APIHandler api = new CurrencyApplication.API.APIHandler();
            String response = await api.getCurrencies();
            Console.WriteLine("response: " + response);
            Console.WriteLine("<< LeituraDeCurrencies");
            Assert.IsNull(response);
        }
    }
}
