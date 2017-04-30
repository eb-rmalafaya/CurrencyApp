using CurrencyApplication.ViewModels;
using System;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CurrencyApplication.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.ListView.ItemSelected += OnItemSelected;

             if(Device.RuntimePlatform == Device.Windows)
            {
                Master.Icon = "swap.png";
            }       
           }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}

