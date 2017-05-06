using CurrencyApplication.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApplication.Database
{
    public class UserWalletDatabase
    {
        readonly SQLiteAsyncConnection database;

        public UserWalletDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Wallet>().Wait();
        }

        public Task<List<Wallet>> GetWallets()
        {
            return database.Table<Wallet>().ToListAsync();
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
