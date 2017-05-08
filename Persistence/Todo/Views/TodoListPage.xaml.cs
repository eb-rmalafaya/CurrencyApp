using System;
using System.Diagnostics;
using Todo.Models;
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
            // atualizar currencies

            // mudar label
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((App)App.Current).ResumeAtTodoId = (e.SelectedItem as Wallet).ID;
			Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as Wallet).ID);

			await Navigation.PushAsync(new TodoItemPage
			{
				BindingContext = e.SelectedItem as Wallet
            });
		}
	}
}
