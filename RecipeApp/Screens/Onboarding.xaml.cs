namespace RecipeApp.Screens;

public partial class Onboarding : ContentPage
{
	public Onboarding()
	{
		InitializeComponent();

		
	}
    private void OnButtonClicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Main());
        
    }
}
