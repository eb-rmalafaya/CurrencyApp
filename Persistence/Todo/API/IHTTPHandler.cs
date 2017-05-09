using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApp.API
{
    interface IHTTPHandler
    {
        IAsyncResult Get(string uri, AsyncCallback cb);
    }
}
