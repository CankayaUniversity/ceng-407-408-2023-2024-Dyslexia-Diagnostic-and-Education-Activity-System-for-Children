using DyslexiaApp.MAUI.ViewModels;

namespace DyslexiaApp.MAUI.Pages.Login;

public partial class DiagnosisSymmetryInfo : ContentPage
{
    private readonly DiagnosisMatchingGamesViewModel _diagnosisMatchingGamesViewModel;

    public DiagnosisSymmetryInfo(DiagnosisMatchingGamesViewModel diagnosisMatchingGamesViewModel)
    {
        InitializeComponent();
        _diagnosisMatchingGamesViewModel = diagnosisMatchingGamesViewModel;
        BindingContext = _diagnosisMatchingGamesViewModel;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        _diagnosisMatchingGamesViewModel.ResetSymmetry();
        await _diagnosisMatchingGamesViewModel.SelectDefaultGame1();
    }

    private async void Close_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}