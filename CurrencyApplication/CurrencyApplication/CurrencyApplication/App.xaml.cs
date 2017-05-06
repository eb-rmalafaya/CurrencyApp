using CurrencyApplication.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CurrencyApplication
{

    public partial class App : Application
    {
        static UserWalletDatabase database;

        public App()
        {
            InitializeComponent();
            MainPage = new CurrencyApplication.Views.ListViewPage();
        }

        public static UserWalletDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new UserWalletDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtTodoId { get; set; }

    }
}
