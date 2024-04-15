namespace DyslexiaApp.MAUI.Pages.Login;

public partial class DiagnosisSymmetryInfo : ContentPage
{
	public DiagnosisSymmetryInfo()
	{
		InitializeComponent();
	}

    private async void Close_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}