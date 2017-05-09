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
                string toSymbol = (string)Currency.SelectedItem;
                //Get Wallets
                List<Wallet> wallets = await App.Database.GetItemsAsync();
                foreach (Wallet wallet in wallets)
                {
                    await APIHandler.Convert(wallet.Symbol, toSymbol, wallet, wallet.Quantity);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            await Navigation.PopToRootAsync();
        }

    }
}