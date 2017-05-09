using System;
using System.Collections.Generic;
using CurrencyApp.Models;
using Xamarin.Forms;

namespace CurrencyApp
{
	public partial class CurrencyAppItemPage : ContentPage
	{
		public CurrencyAppItemPage()
		{
			InitializeComponent();
		}

		async void OnSaveClicked(object sender, EventArgs e)
		{
            bool entered = false;
            var CurrencyAppItem = (Wallet)BindingContext;
            List<Wallet> wallets = await App.Database.GetItemsAsync();
            Wallet wallet = new Wallet();
            if (wallets.Count > 0)
            {
                foreach (Wallet w in wallets)
                {
                    if (w.Symbol.Equals(CurrencyAppItem.Symbol))
                    {
                        wallet = w;
                        entered = true;
                        break;
                    }
                }
                if (entered == true)
                {
                    wallet.Quantity = wallet.Quantity + CurrencyAppItem.Quantity;
                    await App.Database.SaveItemAsync(wallet);
                }
                else
                {
                    await App.Database.SaveItemAsync(CurrencyAppItem);
                }
                
            }
            else
            {
                await App.Database.SaveItemAsync(CurrencyAppItem);
            }
            
			await Navigation.PopAsync();
		}

		async void OnCancelClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		void OnSpeakClicked(object sender, EventArgs e)
		{
			var CurrencyAppItem = (Wallet)BindingContext;
			DependencyService.Get<ITextToSpeech>().Speak(CurrencyAppItem.Quantity + " " + CurrencyAppItem.Symbol);
		}
	}
}
