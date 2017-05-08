using System;
using System.Collections.Generic;
using System.Diagnostics;
using Todo.API;
using Todo.Models;
using Todo.Views;
using Xamarin.Forms;

namespace Todo
{
	public partial class TodoListPage : ContentPage
	{
        public TodoListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
            refreshLabel.Text = "Last Update: " + await App.DatabaseCurrencies.GetLastUpdateTimeString();

        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new Wallet()
            });
        }

        async void OnRefresh(object sender, EventArgs e)
        {
            if (Utils.Utils.hasInternetAccess())
            {
                // atualizar currencies
                APIHandler api = new APIHandler();
                List<CurrencyDTO> package = null;
                try
                {
                    package = api.GetCurrenciesDTO();
                    String gg = "Go";
                    if (package != null)
                    {
                        refreshLabel.Text = "Last Update: " + Utils.Utils.getCurrentDateString();
                        await App.DatabaseCurrencies.SaveItemsAsync(package);
                    }
                }
                catch (Exception exception)
                {
                    // show dialog
                    String var = "Ola";
                    //await DisplayAlert("Warning", "The API is currently unavailable. Please Try Again", "OK");
                }
                // mudar label
            }
            else
            {
                // no internet show access
                String heho = "No Internet";
                await DisplayAlert("Warning", "No Internet Access. Please Connect to the Internet.", "OK");

            }

        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((App)App.Current).ResumeAtTodoId = (e.SelectedItem as Wallet).ID;
			Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as Wallet).ID);
            Wallet w = (e.SelectedItem as Wallet);

            
            await Navigation.PushAsync(new UpdateWallet
            {
				BindingContext = e.SelectedItem as Wallet,
            });
            
		}
        
	}
}
