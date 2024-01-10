using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
namespace RecipeApp.Screens;

public class RecipeRepository
{
    private readonly string databasePath;
    private SQLiteConnection database;

    public RecipeRepository(string databasePath)
    {
        this.databasePath = databasePath;
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        if (database == null)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Recipe>();
        }
    }

    public List<Recipe> GetAllRecipes()
    {
        return database.Table<Recipe>().ToList();
    }

    public Recipe GetRecipeById(int id)
    {
        return database.Table<Recipe>().FirstOrDefault(r => r.Id == id);
    }

    public void AddRecipe(Recipe recipe)
    {
        database.Insert(recipe);
    }

    public void UpdateRecipe(Recipe recipe)
    {
        database.Update(recipe);
    }

    public void DeleteRecipe(int id)
    {
        database.Delete<Recipe>(id);
    }
    
}