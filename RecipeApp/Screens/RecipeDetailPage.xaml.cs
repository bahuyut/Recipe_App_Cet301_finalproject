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

            // Seçilen yemeğin bilgilerini görüntüle
            if (selectedRecipe != null)
            {
                // recipeImage.Source satırını çıkarttık
                this.BindingContext = selectedRecipe;
            }
        }private async void AddToMarketList_Clicked(object sender, EventArgs e)
{
    if (BindingContext is Recipe selectedRecipe)
    {
        MarketItem marketItem = new MarketItem
        {
            Name = selectedRecipe.Ingredients // Burada Ingredients property'sini ekleyerek malzemeleri ekleyebilirsiniz, ancak gerektiğinde uygun bir şekilde ayarlamalısınız
        };

        await new MarketlistRepository().AddItem(marketItem);
        await DisplayAlert("Başarı", "Malzeme Market Listesine Eklendi", "Tamam");

        // Ekleme işlemi bittikten sonra Marketlist sayfasına geri dönme işlemi ekleyebilirsiniz.
        await Navigation.PopAsync(); // Örnek bir geri dönme işlemi
    }
}

        private async void AddToMarketList_Clickedd(object sender, EventArgs e)
        {
            if (BindingContext is Recipe selectedRecipe)
            {
                MarketItem marketItem = new MarketItem
                {
                    Name = selectedRecipe.Ingredients // Burada Ingredients property'sini ekleyerek malzemeleri ekleyebilirsiniz, ancak gerektiğinde uygun bir şekilde ayarlamalısınız
                };

                await new MarketlistRepository().AddItem(marketItem);
                await DisplayAlert("Başarı", "Malzeme Market Listesine Eklendi", "Tamam");

                // Ekleme işlemi bittikten sonra Marketlist sayfasına geri dönme işlemi ekleyebilirsiniz.
                await Navigation.PopAsync(); // Örnek bir geri dönme işlemi
            }
        }

        private void StartCountdown(object sender, EventArgs e)
        {
            if (!isCountdownRunning && countdownPicker.Time != null)
            {
                // Get the selected time from TimePicker
                var selectedTime = countdownPicker.Time;

                // Calculate the total seconds
                countdownSeconds = selectedTime.Hours * 3600 + selectedTime.Minutes * 60 + selectedTime.Seconds;

                // Set the countdown end time
                countdownEndTime = DateTime.Now.AddSeconds(countdownSeconds);
                isCountdownRunning = true;

                // Start the countdown
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
            // Check if the countdown is stopped
            if (!isCountdownRunning)
            {
                return false; // Stop the timer
            }

            // Calculate remaining seconds
            var remainingSeconds = (int)Math.Max(0, (countdownEndTime - DateTime.Now).TotalSeconds);

            // Update the countdown label
            countdownLabel.Text = $"Kalan Süre: {TimeSpan.FromSeconds(remainingSeconds).ToString(@"hh\:mm\:ss")}";

            // Check if the countdown is completed
            if (remainingSeconds == 0)
            {
                countdownLabel.Text = "Süre Doldu!";
                isCountdownRunning = false; // Stop the countdown
                return false; // Stop the timer
            }

            return true; // Continue the timer
        }
    }
}
