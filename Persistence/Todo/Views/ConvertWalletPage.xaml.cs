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
            createPicker();
            createButton();
            

            var contentView = new ContentView
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Children = {
                     Currency,
                     Button,
                 }
                }
            };
            Content = contentView;
        }

        private void createPicker()
        {
            Currency = new Picker { Title = "Choose" };
            foreach (String symbol in CurrencyDTO.top10Currencies)
            {
                if (Currency.SelectedIndex != 0) Currency.SelectedIndex = 0;
                Currency.Items.Add(symbol);
            }
        }

        private void createButton()
        {
            Button = new Button { Text = "Convert" };
            Button.Clicked += delegate
            {
                OnConvert();
            };
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

    }
}