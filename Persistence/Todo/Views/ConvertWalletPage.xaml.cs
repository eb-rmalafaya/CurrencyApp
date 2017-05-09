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
            foreach (String symbol in CurrencyDTO.top10Currencies)
            {
                if (Currency.SelectedIndex != 0) Currency.SelectedIndex = 0;
                Currency.Items.Add(symbol);
            }
        }

        async void OnConvert(object sender, EventArgs e)
        {
            try
            {

                List<string> currenciesNames = CurrencyDTO.top10Currencies.ToList<String>();

                CurrencyDTO currency = null;
                List<CurrencyDTO> currencies = new List<CurrencyDTO>();

                string symbol = (string)Currency.SelectedItem;


                //Get wanted currency
                currency = await App.DatabaseCurrencies.GetLastUpdateTimeString(convertToAPIFormat(symbol));

                //Get Wallets
                List<Wallet> wallets = await App.Database.GetItemsAsync();

                if (wallets != null)
                {
                    if (wallets.Count > 0)
                    {
                        //Get other currencies
                        foreach (string currencyName in currenciesNames)
                        {
                            if (!currencyName.Equals(symbol))
                            {
                                CurrencyDTO dto = await App.DatabaseCurrencies.GetLastUpdateTimeString(convertToAPIFormat(currencyName));
                                if (dto != null)
                                {
                                    currencies.Add(dto);
                                }

                            }
                        }
                        if (currencies.Count > 0)
                        {
                            //Find wanted wallet
                            Wallet wantedWallet = wallets.Find(x => x.Symbol.Equals(symbol));

                            //Sum quantiy
                            APIHandler api = new APIHandler();
                            double quantity = 0.0;
                            if (wantedWallet != null)
                            {
                                quantity = wantedWallet.Quantity;
                            }
                            foreach (CurrencyDTO c in currencies)
                            {
                                Wallet finalWallet = wallets.Find(x => x.Symbol.Equals(revertFromAPIFormat(c.Symbol)));
                                if (finalWallet != null)
                                {
                                    double quantityF = finalWallet.Quantity;
                                    double value = api.Convert(c, currency, quantityF);
                                    quantity = quantity + value;
                                }

                            }

                            //Update quantity
                            if (wantedWallet == null)
                                wantedWallet = new Wallet(quantity, symbol);

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
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            await Navigation.PopAsync();

        }

        private string convertToAPIFormat(string currency)
        {
            return currency + "=X";
        }

        private string revertFromAPIFormat(string currency)
        {
            //EUR=X
            return currency.Substring(0, 3);
        }

    }
}