namespace DyslexiaApp.MAUI.Pages.Login;

public partial class EducationalGameList : ContentPage
{
	public EducationalGameList()
	{
		InitializeComponent();
	}

    private async void Close_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(EducationalGameList)}");
    }

    private void OnFrameTapped(object sender, EventArgs e)
    {
        popupContentView.IsVisible = true;
    }

    private async void NavigateButtonClicked(object sender, EventArgs e)
    {
        popupContentView.IsVisible = false;
        await Navigation.PushAsync(new PictureMatchingGame()); 
    }

}