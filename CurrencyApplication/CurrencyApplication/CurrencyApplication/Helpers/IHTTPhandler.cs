using CurrencyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApplication.Helpers
{
    interface IHTTPhandler
    {
        Task<String> RefreshDataAsync(String url);
       
    }
}
