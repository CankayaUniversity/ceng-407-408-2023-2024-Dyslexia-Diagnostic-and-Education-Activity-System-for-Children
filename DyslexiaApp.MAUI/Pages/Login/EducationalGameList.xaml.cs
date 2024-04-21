using DyslexiaApp.MAUI.ViewModels;

namespace DyslexiaApp.MAUI.Pages.Login;

public partial class EducationalGameList : ContentPage
{
    private readonly EducationalGamesViewModel _educationalGamesViewModel;

    public EducationalGameList(EducationalGamesViewModel educationalGamesViewModel)
    {
        InitializeComponent();
        _educationalGamesViewModel = educationalGamesViewModel;
        BindingContext = _educationalGamesViewModel;
    }

    protected async override void OnAppearing()
    {
        await _educationalGamesViewModel.InitializeAsync();
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