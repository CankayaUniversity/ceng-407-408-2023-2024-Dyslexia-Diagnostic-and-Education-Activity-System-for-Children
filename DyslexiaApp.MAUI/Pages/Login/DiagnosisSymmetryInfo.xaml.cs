using DyslexiaApp.MAUI.ViewModels;

namespace DyslexiaApp.MAUI.Pages.Login;

public partial class DiagnosisSymmetryInfo : ContentPage
{
    private readonly DiagnosisSymmetryMatchViewModel _diagnosisSymmetryMatchViewModel;

    public DiagnosisSymmetryInfo(DiagnosisSymmetryMatchViewModel diagnosisSymmetryMatchViewModel)
    {
        InitializeComponent();
        _diagnosisSymmetryMatchViewModel = diagnosisSymmetryMatchViewModel;
        BindingContext = _diagnosisSymmetryMatchViewModel;
    }

    protected async override void OnAppearing()
    {
        await _diagnosisSymmetryMatchViewModel.InitializeAsync();
    }

    private async void Close_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}