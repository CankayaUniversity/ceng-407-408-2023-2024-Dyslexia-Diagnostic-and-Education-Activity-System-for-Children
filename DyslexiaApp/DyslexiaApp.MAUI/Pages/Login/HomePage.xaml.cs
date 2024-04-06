namespace DyslexiaApp.MAUI.Pages.Login;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}
    private async void DiagnosisTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DiagnosticTestAgreement());
    }
    private async void EducationalTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EducationalGameList());
    }

    private async void OnProfileTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfilePage());
    }
}