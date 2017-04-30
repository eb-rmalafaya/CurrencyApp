using CurrencyApplication.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CurrencyApplication
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new CurrencyApplication.Views.MainPage();      
        }

        
    }
}
