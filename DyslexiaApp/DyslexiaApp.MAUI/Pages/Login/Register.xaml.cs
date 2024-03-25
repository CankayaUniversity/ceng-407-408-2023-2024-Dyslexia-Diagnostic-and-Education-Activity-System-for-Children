namespace DyslexiaApp.MAUI.Pages.Login;

using DyslexiaApp.MAUI.ViewModels;
public partial class Register : ContentPage
{
	public Register( AuthViewModel authViewModel)
	{
		InitializeComponent();
        BindingContext = authViewModel;
	}
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}