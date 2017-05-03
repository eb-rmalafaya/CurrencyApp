using CurrencyApplication.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApplication.Database
{
    class UserWalletDatabase
    {
        readonly SQLiteAsyncConnection database;

        public UserWalletDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<UserSettings>().Wait();
        }

        public Task<UserSettings> GetUserSettings()
        {
            return database.Table<UserSettings>().FirstAsync();
        }

        public Task<UserSettings> GetItemAsync(int id)
        {
            return database.Table<UserSettings>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(UserSettings item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(UserSettings item)
        {
            return database.DeleteAsync(item);
        }
    }
}
