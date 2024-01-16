﻿using RecipeApp.Screens;
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
            UpdateClearAllButtonVisibility();
        }

        private async Task UpdateMarketList()
        {
            var items = await marketlistRepository.GetAllItems();
            marketListView.ItemsSource = items;

            emptyListLabel.IsVisible = items.Count == 0;
            UpdateClearAllButtonVisibility(); 
        }
        private void UpdateClearAllButtonVisibility()
        {
            clearAllButton.IsVisible = marketListView.ItemsSource?.Cast<MarketItem>().Any() == true;
        }
        private async void OnClearAllClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Uyarı", "Tümünü silmek istediğinize emin misiniz?", "Evet", "Hayır");

            if (answer)
            {
                await marketlistRepository.ClearAllItems();
                await UpdateMarketList();
            }
        }
        private async void OnAddClicked(object sender, EventArgs e)
        {
            MarketItem item = new MarketItem
            {
                Name = itemEntry.Text,
            };

            await marketlistRepository.AddItem(item);
            itemEntry.Text = string.Empty; 
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
