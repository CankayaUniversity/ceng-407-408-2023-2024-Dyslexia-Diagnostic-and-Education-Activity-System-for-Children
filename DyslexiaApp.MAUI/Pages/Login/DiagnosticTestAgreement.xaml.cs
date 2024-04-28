namespace DyslexiaApp.MAUI.Pages.Login;

public partial class DiagnosticTestAgreement : ContentPage
{
    public DiagnosticTestAgreement()
    {
        InitializeComponent();
    }
    private async void Close_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
    private async void GoTestInfo_Clicked(object sender, EventArgs e)
    {
        if (AgreementCheckBox.IsChecked)
        {
            await Shell.Current.GoToAsync($"//{nameof(DiagnosisLetterMatchingInformation)}");
        }
        else
        {
            await DisplayAlert("Warning", "You must agree to the terms and conditions before start first test.", "OK");
        }

    }
}