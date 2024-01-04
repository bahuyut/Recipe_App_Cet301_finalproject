using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Screens
{
    public class MarketlistRepository
    {
        private SQLiteAsyncConnection database;
        private string databaseName = "marketitems.db3";


        public MarketlistRepository()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, databaseName);
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<MarketItem>(CreateFlags.AllImplicit | CreateFlags.AutoIncPK).GetAwaiter().GetResult();
        }

        public async Task<List<MarketItem>> GetAllItems()
        {
            return await database.Table<MarketItem>().ToListAsync();
        }

        public async Task AddItem(MarketItem item)
        {
            await database.InsertAsync(item);

        }
        public async Task DeleteItem(MarketItem item)
        {
            await database.DeleteAsync(item);

        }
    }
}