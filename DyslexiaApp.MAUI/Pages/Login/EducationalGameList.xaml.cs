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

    private async void Home_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }



}