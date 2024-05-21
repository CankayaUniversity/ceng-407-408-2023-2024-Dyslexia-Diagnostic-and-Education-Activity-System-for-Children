using DyslexiaApp.MAUI.ViewModels;

namespace DyslexiaApp.MAUI.Pages.Login;

public partial class DiagnosisNavigationInfo : ContentPage
{
    private readonly DiagnosisNavigationViewModel _diagnosisNavigationViewModel;

    public DiagnosisNavigationInfo(DiagnosisNavigationViewModel diagnosisNavigationViewModel)
    {
        InitializeComponent();
        _diagnosisNavigationViewModel = diagnosisNavigationViewModel;
        BindingContext = _diagnosisNavigationViewModel;
    }


    private async void Close_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }

}