namespace RecipeApp.Screens;

public partial class Main : ContentPage
{
	public Main()
	{
		InitializeComponent();

        
    }
    
    void KarnıyarıkTapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Navigation.PushAsync(new Karnıyarık());

    }
    void KurufasulyeTapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Navigation.PushAsync(new Kurufasulye());

    }
    void MantıTapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Navigation.PushAsync(new Mantı());

    }
    private void MarketlistClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Marketlist());

    }

}
