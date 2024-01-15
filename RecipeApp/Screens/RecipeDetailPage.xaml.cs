using Microsoft.Maui.Controls;

namespace RecipeApp.Screens
{
    public partial class RecipeDetailPage : ContentPage
    {
        public RecipeDetailPage(Recipe selectedRecipe)
        {
            InitializeComponent();

            // Seçilen yemeğin bilgilerini görüntüle
            if (selectedRecipe != null)
            {
                // recipeImage.Source satırını çıkarttık
                this.BindingContext = selectedRecipe;
            }
        }
        

    }
}
