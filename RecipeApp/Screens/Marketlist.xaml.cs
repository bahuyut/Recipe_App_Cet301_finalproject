using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace RecipeApp.Screens
{
    public partial class Marketlist : ContentPage
    {
        public ObservableCollection<MarketItem> MarketItems { get; set; }

        

        public Marketlist()
        {
            InitializeComponent();
            MarketItems = new ObservableCollection<MarketItem>();
            marketListView.ItemsSource = MarketItems;
            UpdateEmptyListLabelVisibility();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var item = (MarketItem)((Button)sender).CommandParameter;

            bool answer = await DisplayAlert("Sil", $"Emin misiniz? {item.Name} silinecek.", "Evet", "Hayır");

            if (answer)
            {
                MarketItems.Remove(item);
            }

            UpdateEmptyListLabelVisibility();
        }



        private void OnAddClicked(object sender, EventArgs e)
        {
            var newItem = new MarketItem { Name = itemEntry.Text };
            MarketItems.Add(newItem);
            itemEntry.Text = "";

            UpdateEmptyListLabelVisibility();
        }

        private void UpdateEmptyListLabelVisibility()
        {
            emptyListLabel.IsVisible = MarketItems.Count == 0;
        }

    }
}