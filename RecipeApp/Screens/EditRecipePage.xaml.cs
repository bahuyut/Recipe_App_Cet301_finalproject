using Microsoft.Maui.Controls;

namespace RecipeApp.Screens
{
    public partial class EditRecipePage : ContentPage
    {
        private RecipeRepository recipeRepository;
        private Recipe selectedRecipe;

        public EditRecipePage(Recipe recipe)
        {
            InitializeComponent();

            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "recipes.db");

            recipeRepository = new RecipeRepository(databasePath);
            selectedRecipe = recipe;

            recipeNameEntry.Text = selectedRecipe.Name;
            ingredientsEditor.Text = selectedRecipe.Ingredients;
            instructionsEditor.Text = selectedRecipe.Instructions;
        }

        private async void UpdateRecipeClicked(object sender, EventArgs e)
        {
            selectedRecipe.Name = recipeNameEntry.Text;
            selectedRecipe.Ingredients = ingredientsEditor.Text;
            selectedRecipe.Instructions = instructionsEditor.Text;

            recipeRepository.UpdateRecipe(selectedRecipe);

            await DisplayAlert("Başarılı", "Güncelleme başarıyla tamamlandı!", "Tamam");

            await Navigation.PopAsync();
        }

    }
}
