using Todo.Models;
using Xamarin.Forms;

namespace Todo
{
	public class TodoItemPageCS : ContentPage
	{
		public TodoItemPageCS()
		{
			Title = "Todo Item";

			var nameEntry = new Entry();
			nameEntry.SetBinding(Entry.TextProperty, "Name");

			var symbolEntry = new Picker();
            symbolEntry.SetBinding(Picker.SelectedItemProperty, "Currency");

          	var saveButton = new Button { Text = "Save" };
			saveButton.Clicked += async (sender, e) =>
			{
				var todoItem = (Wallet)BindingContext;
				await App.Database.SaveItemAsync(todoItem);
				await Navigation.PopAsync();
			};

			var deleteButton = new Button { Text = "Delete" };
			deleteButton.Clicked += async (sender, e) =>
			{
				var todoItem = (Wallet)BindingContext;
				await App.Database.DeleteItemAsync(todoItem);
				await Navigation.PopAsync();
			};

			var cancelButton = new Button { Text = "Cancel" };
			cancelButton.Clicked += async (sender, e) =>
			{
				await Navigation.PopAsync();
			};

			var speakButton = new Button { Text = "Speak" };
			speakButton.Clicked += (sender, e) =>
			{
				var todoItem = (Wallet)BindingContext;
				DependencyService.Get<ITextToSpeech>().Speak(todoItem.Quantity + " " + todoItem.Symbol);
			};

			Content = new StackLayout
			{
				Margin = new Thickness(20),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children =
				{
					new Label { Text = "Name" },
					nameEntry,
					new Picker(),
                    symbolEntry,
					saveButton,
					deleteButton,
					cancelButton,
					speakButton
				}
			};
		}
	}
}
