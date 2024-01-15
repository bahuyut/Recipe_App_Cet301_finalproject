using RecipeApp.Screens;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeApp.Screens
{
    public partial class Marketlist : ContentPage
    {
        private MarketlistRepository marketlistRepository;

        public Marketlist()
        {
            InitializeComponent();
            marketlistRepository = new MarketlistRepository();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await UpdateMarketList();
        }

        private async Task UpdateMarketList()
        {
            var items = await marketlistRepository.GetAllItems();
            marketListView.ItemsSource = items;

            // Show/hide the empty list label based on the market list's emptiness
            emptyListLabel.IsVisible = items.Count == 0;
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            MarketItem item = new MarketItem
            {
                Name = itemEntry.Text,
            };

            await marketlistRepository.AddItem(item);
            itemEntry.Text = string.Empty; // Clear the entry after adding an item
            await UpdateMarketList();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            MarketItem itemToDelete = (MarketItem)btn.CommandParameter;

            bool answer = await DisplayAlert("Uyarı", "Silmek istediğinize emin misiniz?", "Evet", "Hayır");

            if (answer)
            {
                await marketlistRepository.DeleteItem(itemToDelete);
                await UpdateMarketList();
            }
        }
    }
}
