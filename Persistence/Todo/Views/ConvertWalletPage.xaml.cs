using CurrencyApp.API;
using CurrencyApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CurrencyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConvertWalletPage : ContentPage
    {
        private Picker Currency;
        private Button Button;

        public ConvertWalletPage()
        {
            //InitializeComponent();

            Currency = new Picker { Title = "Choose" };
            foreach (String symbol in CurrencyDTO.top10Currencies)
            {
                if (Currency.SelectedIndex != 0) Currency.SelectedIndex = 0;
                Currency.Items.Add(symbol);
            }
                     
            //
            Button button = new Button { Text = "Convert" };
            button.Clicked += delegate
            {
                OnConvert();
            };

            var contentView = new ContentView
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Children = {
                     Currency,
                     button,
                 }
                }
            };
            Content = contentView;
        }

        async void OnConvert()
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