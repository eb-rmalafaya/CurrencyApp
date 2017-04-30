using CurrencyApplication.ViewModels;
using CurrencyApplication.Views;
using System.Collections.Generic;


using Xamarin.Forms;

namespace CurrencyApplication.Views
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        public MasterPage()
        {
            InitializeComponent();

            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Profile",
                IconSource = "profile_generic.png",
                TargetType = typeof(AboutPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Wallet",
                IconSource = "profile_generic.png",
                TargetType = typeof(AboutPage)
            });

            listView.ItemsSource = masterPageItems;
        }
    }
}
