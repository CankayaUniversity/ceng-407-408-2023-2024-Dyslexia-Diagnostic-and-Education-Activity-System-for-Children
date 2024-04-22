using DyslexiaApp.MAUI.ViewModels;

namespace DyslexiaApp.MAUI.Pages.Login;

public partial class PictureMatchingGame : ContentPage
{
    public PictureMatchingGame(PictureMatchingViewModel pictureViewModel)
    {
        InitializeComponent();
        BindingContext = pictureViewModel;

    }

    private async void Home_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}