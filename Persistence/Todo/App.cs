using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using Todo.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Todo
{
	public class App : Application
	{
		static TodoItemDatabase database;
        static CurrencyDTODatabase databaseCurrencies;

        public App()
		{
			Resources = new ResourceDictionary();
			Resources.Add("primaryDarkGrey", Color.FromHex("47525E"));
			Resources.Add("primaryWhiteGrey", Color.FromHex("F0F0F0"));

			var nav = new NavigationPage(new TodoListPage());
			nav.BarBackgroundColor = (Color)App.Current.Resources["primaryDarkGrey"];
			nav.BarTextColor = Color.White;
            nav.BackgroundColor = (Color)App.Current.Resources["primaryWhiteGrey"];
            MainPage = nav;
		}

		public static TodoItemDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new TodoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
				}
				return database;
			}
		}

		public int ResumeAtTodoId { get; set; }

        public static CurrencyDTODatabase DatabaseCurrencies
        {
            get
            {
                if (databaseCurrencies == null)
                {
                    databaseCurrencies = new CurrencyDTODatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
                }
                return databaseCurrencies;
            }
        }

    }
}

