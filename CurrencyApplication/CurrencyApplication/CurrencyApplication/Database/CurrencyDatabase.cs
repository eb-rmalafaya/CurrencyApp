using CurrencyApplication.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyApplication.Database
{
    class CurrencyDatabase
    {
        readonly SQLiteAsyncConnection database;

        public CurrencyDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<CurrenciesPackage>().Wait();
        }

        public Task<List<CurrenciesPackage>> GetItemsAsync()
        {
            return database.Table<CurrenciesPackage>().ToListAsync();
        }

        public Task<List<CurrenciesPackage>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<CurrenciesPackage>("SELECT * FROM [CurrenciesPackage] ORDER BY [RequestTimestamp] DESC");
        }

        public Task<CurrenciesPackage> GetItemAsync(int id)
        {
            return database.Table<CurrenciesPackage>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(CurrenciesPackage item)
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

        public Task<int> DeleteItemAsync(CurrencyDTO item)
        {
            return database.DeleteAsync(item);
        }
    }
}
