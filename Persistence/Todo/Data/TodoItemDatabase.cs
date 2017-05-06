using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Todo.Models;

namespace Todo
{
	public class TodoItemDatabase
	{
		readonly SQLiteAsyncConnection database;

		public TodoItemDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<Wallet>().Wait();
		}

		public Task<List<Wallet>> GetItemsAsync()
		{
			return database.Table<Wallet>().ToListAsync();
		}

		public Task<List<Wallet>> GetItemsNotDoneAsync()
		{
			return database.QueryAsync<Wallet>("SELECT * FROM [Wallet] WHERE [Done] = 0");
		}

		public Task<Wallet> GetItemAsync(int id)
		{
			return database.Table<Wallet>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(Wallet item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else {
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(Wallet item)
		{
			return database.DeleteAsync(item);
		}
	}
}

