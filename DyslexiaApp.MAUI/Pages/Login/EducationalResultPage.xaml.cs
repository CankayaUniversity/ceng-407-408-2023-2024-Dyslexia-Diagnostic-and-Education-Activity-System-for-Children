using DyslexiaApp.MAUI.ViewModels;

namespace DyslexiaApp.MAUI.Pages.Login;

public partial class EducationalResultPage : ContentPage
{
    private readonly EducationalGamesViewModel _educationalGamesViewModel;

    public EducationalResultPage(EducationalGamesViewModel educationalGamesViewModel)
    {
        InitializeComponent();
        _educationalGamesViewModel = educationalGamesViewModel;
        BindingContext = _educationalGamesViewModel;
    }
    private async void Close_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}