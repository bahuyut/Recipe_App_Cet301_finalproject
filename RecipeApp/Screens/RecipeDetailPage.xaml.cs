using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace RecipeApp.Screens
{
    public partial class RecipeDetailPage : ContentPage
    {
        private int countdownSeconds;
        private DateTime countdownEndTime;
        private bool isCountdownRunning;

        public RecipeDetailPage(Recipe selectedRecipe)
        {
            InitializeComponent();

            if (selectedRecipe != null)
            {
                this.BindingContext = selectedRecipe;
            }
        }private async void AddToMarketList_Clicked(object sender, EventArgs e)
{
    if (BindingContext is Recipe selectedRecipe)
    {
        MarketItem marketItem = new MarketItem
        {
            Name = selectedRecipe.Ingredients 
        };

        await new MarketlistRepository().AddItem(marketItem);
        await DisplayAlert("Başarı", "Malzeme Market Listesine Eklendi", "Tamam");

        await Navigation.PopAsync(); 
    }
}

        private async void AddToMarketList_Clickedd(object sender, EventArgs e)
        {
            if (BindingContext is Recipe selectedRecipe)
            {
                string[] lines = selectedRecipe.Ingredients.Split('\n'); 
                List<string> ingredients = new List<string>();

                foreach (var line in lines)
                {
                    
                    string[] commaSeparated = line.Split(',');
                    ingredients.AddRange(commaSeparated.Select(ingredient => ingredient.Trim()));
                }

                foreach (var ingredient in ingredients)
                {
                    if (!string.IsNullOrWhiteSpace(ingredient))
                    {
                        MarketItem marketItem = new MarketItem
                        {
                            Name = ingredient
                        };

                        await new MarketlistRepository().AddItem(marketItem);
                    }
                }

                await DisplayAlert("Başarı", "Malzemeler Market Listesine Eklendi", "Tamam");

              
            }
        }



        private void StartCountdown(object sender, EventArgs e)
        {
            if (!isCountdownRunning && countdownPicker.Time != null)
            {
                var selectedTime = countdownPicker.Time;

                countdownSeconds = selectedTime.Hours * 3600 + selectedTime.Minutes * 60 + selectedTime.Seconds;

                countdownEndTime = DateTime.Now.AddSeconds(countdownSeconds);
                isCountdownRunning = true;

                Device.StartTimer(TimeSpan.FromSeconds(1), UpdateCountdownLabel);
            }
        }

        private void StopCountdown(object sender, EventArgs e)
        {
            isCountdownRunning = false;
        }

        private void ResetCountdown(object sender, EventArgs e)
        {
            isCountdownRunning = false;
            countdownLabel.Text = "";
            countdownPicker.Time = TimeSpan.Zero;
        }

        private bool UpdateCountdownLabel()
        {
            if (!isCountdownRunning)
            {
                return false; 
            }

            var remainingSeconds = (int)Math.Max(0, (countdownEndTime - DateTime.Now).TotalSeconds);

            countdownLabel.Text = $"Kalan Süre: {TimeSpan.FromSeconds(remainingSeconds).ToString(@"hh\:mm\:ss")}";

            if (remainingSeconds == 0)
            {
                countdownLabel.Text = "Süre Doldu!";
                isCountdownRunning = false; 
                return false; 
            }

            return true; 
        }
    }
}
