namespace DyslexiaApp.MAUI.Pages.Login;

public partial class RegisterAgreement : ContentPage
{
	public RegisterAgreement()
	{
		InitializeComponent();
	}

    private async void OnCloseButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(Register)}");
    }
    private async void OnRegisterAgreementButtonClicked(object sender, EventArgs e)
    {
        if (AgreementCheckBox.IsChecked)
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
        else
        {
            await DisplayAlert("Warning", "You must agree to the terms and conditions before registering.", "OK");
        }

    }
}