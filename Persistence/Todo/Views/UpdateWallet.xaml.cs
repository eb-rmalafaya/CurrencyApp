using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateWallet : ContentPage
    {
        public UpdateWallet()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
        }

        async void OnUpdateClicked(object sender, EventArgs e)
        {
            var wallet = (Wallet)BindingContext;
            await App.Database.SaveItemAsync(wallet);
            await Navigation.PopAsync();

        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (Wallet)BindingContext;
            await App.Database.DeleteItemAsync(todoItem);
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
