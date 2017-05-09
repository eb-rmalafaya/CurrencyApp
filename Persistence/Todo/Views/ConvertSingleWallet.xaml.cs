using CurrencyApp.API;
using CurrencyApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CurrencyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConvertSingleWallet : ContentPage
    {
        private Double oldQuantity;

        public ConvertSingleWallet(Wallet currencyAppItem)
        {
            InitializeComponent();
            //var CurrencyAppItem = (Wallet)BindingContext;
            try
            {
                oldQuantity = currencyAppItem.Quantity;

                foreach (String symbol in CurrencyDTO.top10Currencies)
                {
                    if (Picker.SelectedIndex != 0) Picker.SelectedIndex = 0;
                    if (!currencyAppItem.Symbol.Contains(symbol)) Picker.Items.Add(symbol);
                }
            }
            catch (Exception e)
            {
                var ola = "";
            }

        }

        async void OnConvertClicked(object sender, EventArgs e)
        {
            Wallet currencyAppItem = (Wallet)BindingContext;
            Double selectedQuantity = currencyAppItem.Quantity;
            currencyAppItem.Quantity = oldQuantity;
            string toSymbol = (string)Picker.SelectedItem;
            // convert
            await APIHandler.Convert(currencyAppItem.Symbol, toSymbol, currencyAppItem, selectedQuantity);
            await Navigation.PopToRootAsync();
        }
    }
}
