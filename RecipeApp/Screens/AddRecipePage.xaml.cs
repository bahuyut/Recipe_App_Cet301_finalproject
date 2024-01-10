using System;
using Microsoft.Maui.Controls;

namespace RecipeApp.Screens
{
    public partial class AddRecipePage : ContentPage
    {
        private RecipeRepository recipeRepository;

        public AddRecipePage()
        {
            InitializeComponent();

            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "recipes.db");
            recipeRepository = new RecipeRepository(databasePath);
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(recipeNameEntry.Text) || string.IsNullOrWhiteSpace(ingredientsEntry.Text) || string.IsNullOrWhiteSpace(instructionsEntry.Text))
            {
                DisplayAlert("Uyarı", "Lütfen tüm alanları doldurun.", "Tamam");
                return;
            }

            Recipe newRecipe = new Recipe
            {
                Name = recipeNameEntry.Text,
                Ingredients = ingredientsEntry.Text,
                Instructions = instructionsEntry.Text
            };

            recipeRepository.AddRecipe(newRecipe);

            DisplayAlert("Başarılı", "Yemek tarifi başarıyla eklendi.", "Tamam");
            Navigation.PopAsync();
        }

    }
}
