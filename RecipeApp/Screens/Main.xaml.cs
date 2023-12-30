namespace RecipeApp.Screens;

public partial class Main : ContentPage
{
	public Main()
	{
		InitializeComponent();

        
    }
    
    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Navigation.PushAsync(new Karnıyarık());

    }

}
