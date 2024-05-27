namespace DyslexiaApp.MAUI.Pages.Login;

public partial class DiagnosisResultPage : ContentPage
{
    public DiagnosisResultPage()
    {
        InitializeComponent();
    }

    private async void GoToProfile(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(ProfilePage)}");
    }

    private async void Close_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}