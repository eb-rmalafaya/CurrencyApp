using System;
using System.Collections.Generic;
using Todo.Models;
using Xamarin.Forms;

namespace Todo
{
	public partial class TodoItemPage : ContentPage
	{
		public TodoItemPage()
		{
			InitializeComponent();
		}

		async void OnSaveClicked(object sender, EventArgs e)
		{
            bool entered = false;
            var todoItem = (Wallet)BindingContext;
            List<Wallet> wallets = await App.Database.GetItemsAsync();
            Wallet wallet = new Wallet();
            if (wallets.Count > 0)
            {
                foreach (Wallet w in wallets)
                {
                    if (w.Symbol.Equals(todoItem.Symbol))
                    {
                        wallet = w;
                        entered = true;
                        break;
                    }
                }
                if (entered == true)
                {
                    wallet.Quantity = wallet.Quantity + todoItem.Quantity;
                    await App.Database.SaveItemAsync(wallet);
                }
                else
                {
                    await App.Database.SaveItemAsync(todoItem);
                }
                
            }
            else
            {
                await App.Database.SaveItemAsync(todoItem);
            }
            
			await Navigation.PopAsync();
		}

		async void OnCancelClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		void OnSpeakClicked(object sender, EventArgs e)
		{
			var todoItem = (Wallet)BindingContext;
			DependencyService.Get<ITextToSpeech>().Speak(todoItem.Quantity + " " + todoItem.Symbol);
		}
	}
}
