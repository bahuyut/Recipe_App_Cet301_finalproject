using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CetContact.Model
{
    public class RecipeRepository
    {
        private SQLiteAsyncConnection database;
        private string databaseName = "recipes.db3";

        public RecipeRepository()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, databaseName);
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Recipe>(CreateFlags.AllImplicit | CreateFlags.AutoIncPK).GetAwaiter().GetResult();
        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            return await database.Table<Recipe>().ToListAsync();
        }

        public async Task AddRecipe(Recipe recipe)
        {
            await database.InsertAsync(recipe);
        }

        public async Task DeleteRecipe(Recipe recipe)
        {
            await database.DeleteAsync(recipe);
        }

        public async Task<Recipe> GetRecipeById(int Id)
        {
            var recipe = await database.Table<Recipe>().Where(c => c.Id == Id).FirstOrDefaultAsync();
            return recipe;
        }

        public async Task Update(Recipe recipe)
        {
            await database.UpdateAsync(recipe);
        }

        public async Task<List<Recipe>> SearchRecipes(string keyword)
        {
            keyword = keyword.ToLower();
            return await database.Table<Recipe>()
                                .Where(c => c.Name.ToLower().Contains(keyword))
                                .ToListAsync();
        }
    }
}
