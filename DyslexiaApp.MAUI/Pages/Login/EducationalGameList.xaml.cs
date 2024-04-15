namespace DyslexiaApp.MAUI.Pages.Login;

public partial class EducationalGameList : ContentPage
{
    public EducationalGameList()
    {
        InitializeComponent();
    }

    private void Close_Button(object sender, EventArgs e)
    {
        popupContentView.IsVisible = false;
    }

    private async void Home_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
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