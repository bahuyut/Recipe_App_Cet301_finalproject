
using Microsoft.Maui.Controls;

namespace RecipeApp.Screens
{
    public partial class Main : ContentPage
    {
        private RecipeRepository recipeRepository;

        public Main()
        {
            InitializeComponent();

            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "recipes.db");

            recipeRepository = new RecipeRepository(databasePath);

            var recipes = recipeRepository.GetAllRecipes();

            recipeListView.ItemsSource = recipes;

            recipeListView.ItemTapped += RecipeListView_ItemTapped;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = e.NewTextValue.ToLower();

            var recipes = recipeRepository.GetAllRecipes();

            // Filter the recipes based on the entered keyword
            var filteredRecipes = recipes.Where(r => r.Name.ToLower().Contains(keyword)).ToList();

            recipeListView.ItemsSource = filteredRecipes;
        }


        private void RecipeListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Recipe selectedRecipe)
            {
                Navigation.PushAsync(new RecipeDetailPage(selectedRecipe));
            }

            recipeListView.SelectedItem = null;
        }
        private void AddRecipeClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddRecipePage());

        }
        private void MarketlistClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Marketlist());

        }

        private async void DeleteRecipeClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is int recipeId)
            {
                bool isConfirmed = await DisplayAlert("Uyarı", "Bu yemeği silmek istediğinden emin misin?", "Evet", "Hayır");

                if (isConfirmed)
                {
                    recipeRepository.DeleteRecipe(recipeId);
                    var recipes = recipeRepository.GetAllRecipes();
                    recipeListView.ItemsSource = recipes;
                }
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var recipes = recipeRepository.GetAllRecipes();
            recipeListView.ItemsSource = recipes;
        }


    }
}
