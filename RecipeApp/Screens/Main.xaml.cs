
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
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var recipes = recipeRepository.GetAllRecipes();
            recipeListView.ItemsSource = recipes;
        }

    }
}
