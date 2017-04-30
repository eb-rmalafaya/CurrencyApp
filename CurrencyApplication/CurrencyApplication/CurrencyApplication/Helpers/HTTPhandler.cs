using CurrencyApplication.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace CurrencyApplication.Helpers
{
    class HTTPHandler : IHTTPhandler
    {
        HttpClient client;

        public List<CurrencyDTO> Items { get; private set; }

        public HTTPHandler()
        {
            var authData = string.Format("{0}:{1}", "Username", "Password");
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public async Task<String> RefreshDataAsync(String url)
        {

            var uri = new Uri(url);
            String content = null;
            try
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();
                    //Items = JsonConvert.DeserializeObject<List<CurrencyDTO>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return content;
        }

        public async Task SaveTodoItemAsync(CurrencyDTO item, bool isNewItem = false)
        {
            // RestUrl = http://developer.xamarin.com:8081/api/todoitems{0}
            var uri = new Uri(string.Format("RestUrl", item.ID));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				TodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        public async Task DeleteTodoItemAsync(string url)
        {
            // RestUrl = http://developer.xamarin.com:8081/api/todoitems{0}
            var uri = new Uri(url);

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				TodoItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }
    }
}
