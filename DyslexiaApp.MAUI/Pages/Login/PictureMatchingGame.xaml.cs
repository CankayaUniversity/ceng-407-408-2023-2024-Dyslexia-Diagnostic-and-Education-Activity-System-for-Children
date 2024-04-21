namespace DyslexiaApp.MAUI.Pages.Login;

public partial class PictureMatchingGame : ContentPage
{
    public PictureMatchingGame()
    {
        InitializeComponent();
    }
    private async void Home_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}