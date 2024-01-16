using System;
using Microsoft.Maui.Controls;
using System.IO; // Path sınıfını kullanmak için eklenen namespace

namespace RecipeApp.Screens
{
    public partial class AddRecipePage : ContentPage
    {
        private RecipeRepository recipeRepository;

        public AddRecipePage()
        {
            InitializeComponent();

            // Path sınıfını kullanmak için gerekli using eklenmiş durumda
            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "recipes.db");
            recipeRepository = new RecipeRepository(databasePath);
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(recipeNameEntry.Text) || string.IsNullOrWhiteSpace(ingredientsEditor.Text) || string.IsNullOrWhiteSpace(instructionsEditor.Text))
            {
                DisplayAlert("Uyarı", "Lütfen tüm alanları doldurun.", "Tamam");
                return;
            }

            Recipe newRecipe = new Recipe
            {
                Name = recipeNameEntry.Text,
                Ingredients = ingredientsEditor.Text,
                Instructions = instructionsEditor.Text
            };

            recipeRepository.AddRecipe(newRecipe);

            DisplayAlert("Başarılı", "Yemek tarifi başarıyla eklendi.", "Tamam");
            Navigation.PopAsync();
        }
    }
}
