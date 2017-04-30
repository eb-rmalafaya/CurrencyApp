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
        Task<List<CurrencyDTO>> RefreshDataAsync();

        Task SaveTodoItemAsync(CurrencyDTO item, bool isNewItem);

        Task DeleteTodoItemAsync(string id);
    }
}
