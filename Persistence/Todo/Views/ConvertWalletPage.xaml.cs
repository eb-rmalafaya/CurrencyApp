using CurrencyApp.API;
using CurrencyApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CurrencyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConvertWalletPage : ContentPage
    {
        public ConvertWalletPage()
        {
            InitializeComponent();
        }

        async void OnConvert(object sender, EventArgs e)
        {
            try
            {
                List<string> currenciesNames = new List<string>();
                currenciesNames.Add("USD");
                currenciesNames.Add("EUR");
                currenciesNames.Add("JPY");
                currenciesNames.Add("GBP");
                currenciesNames.Add("CHF");
                currenciesNames.Add("CNY");
                currenciesNames.Add("SEK");
                currenciesNames.Add("MXN");
                currenciesNames.Add("NOK");
                currenciesNames.Add("KRW");

                CurrencyDTO currency = null;
                List<CurrencyDTO> currencies = new List<CurrencyDTO>();

                string symbol = (string)Currency.SelectedItem;

                //Get wanted currency
                currency = await App.DatabaseCurrencies.GetLastUpdateTimeString(convertToAPIFormat(symbol));

                //Get Wallets
                List<Wallet> wallets = await App.Database.GetItemsAsync();

                //Get other currencies
                foreach (string currencyName in currenciesNames)
                {
                    if (!currencyName.Equals(symbol))
                    {
                        currencies.Add(await App.DatabaseCurrencies.GetLastUpdateTimeString(convertToAPIFormat(currencyName)));
                    }
                }                

                //Find wanted wallet
                Wallet wantedWallet = wallets.Find(x => x.Symbol.Equals(symbol));

                //Sum quantiy
                APIHandler api = new APIHandler();
                double quantity = 1.0;
                foreach(CurrencyDTO c in currencies)
                {
                    double value = api.Convert(c, currency, quantity);
                    quantity = quantity + value;
                }

                //Update quantity
                if (wantedWallet == null)
                {
                    wantedWallet = new Wallet();
                }
                wantedWallet.Quantity = quantity;
                wantedWallet.Symbol = symbol;
                await App.Database.SaveItemAsync(wantedWallet);

                //Delete other types
                foreach (Wallet wallet in wallets)
                {
                    if (!(wallet.Symbol.Equals(symbol)))
                    {
                        await App.Database.DeleteItemAsync(wallet);
                    }
                }
                
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                }
        }

        private string convertToAPIFormat(string currency)
        {
            return currency + "=X";
        }

    }
}