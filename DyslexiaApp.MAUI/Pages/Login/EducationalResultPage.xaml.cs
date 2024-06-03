using DyslexiaApp.MAUI.ViewModels;

namespace DyslexiaApp.MAUI.Pages.Login;

public partial class EducationalResultPage : ContentPage
{
    private readonly DiagnosisMatchingGamesViewModel _diagnosisMatchingGamesViewModel;

    public EducationalResultPage(DiagnosisMatchingGamesViewModel diagnosisMatchingGamesViewModel)
    {
        InitializeComponent();

        _diagnosisMatchingGamesViewModel = diagnosisMatchingGamesViewModel;
        BindingContext = _diagnosisMatchingGamesViewModel;
    }
    private async void Close_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}