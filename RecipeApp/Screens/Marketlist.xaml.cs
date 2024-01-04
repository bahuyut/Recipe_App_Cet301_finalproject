


using RecipeApp.Screens;

namespace RecipeApp.Screens;

public partial class Marketlist : ContentPage
{
    MarketlistRepository marketlistRepository;
    public Marketlist()
    {
        InitializeComponent();
        marketlistRepository = new MarketlistRepository();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var item = await marketlistRepository.GetAllItems();
        marketListView.ItemsSource = item;

    }


    private async void OnAddClicked(object sender, EventArgs e)
    {
        
        

        MarketItem item = new MarketItem
        {
            Name = itemEntry.Text,
            
        };
        await marketlistRepository.AddItem(item);
        var updatedItems = await marketlistRepository.GetAllItems();
            marketListView.ItemsSource = updatedItems;
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        MarketItem itemToDelete = (MarketItem)btn.CommandParameter;

        bool answer = await DisplayAlert("Uyarı", "Silmek istediğinize emin misiniz?", "Evet", "Hayır");

        if (answer)
        {
            await marketlistRepository.DeleteItem(itemToDelete);
            // Liste güncellendikten sonra ListView'ı tekrar güncelle
            var updatedItems = await marketlistRepository.GetAllItems();
            marketListView.ItemsSource = updatedItems;
        }
    }

}