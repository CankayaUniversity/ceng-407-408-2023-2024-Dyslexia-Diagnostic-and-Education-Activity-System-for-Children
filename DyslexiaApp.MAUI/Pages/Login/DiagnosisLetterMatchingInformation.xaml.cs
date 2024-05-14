using DyslexiaApp.MAUI.ViewModels;

namespace DyslexiaApp.MAUI.Pages.Login;

public partial class DiagnosisLetterMatchingInformation : ContentPage
{
    private readonly DiagnosisMatchingGamesViewModel _diagnosisMatchingViewModel;
    public DiagnosisLetterMatchingInformation(DiagnosisMatchingGamesViewModel diagnosisMatchingViewModel)
    {
        InitializeComponent();
        _diagnosisMatchingViewModel = diagnosisMatchingViewModel;
        BindingContext = _diagnosisMatchingViewModel;
    }
    protected async override void OnAppearing()
    {
        await _diagnosisMatchingViewModel.InitializeAsync();
    }
    private async void Close_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}