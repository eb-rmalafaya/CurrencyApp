using CurrencyApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CurrencyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConvertSingleWallet : ContentPage
    {
        public ConvertSingleWallet()
        {
            InitializeComponent();
        }

        async void OnConvertClicked(object sender, EventArgs e)
        {
            var CurrencyAppItem = (Wallet)BindingContext;
            //await App.Database.DeleteItemAsync(CurrencyAppItem);
            //await Navigation.PopAsync();
        }
    }
}
