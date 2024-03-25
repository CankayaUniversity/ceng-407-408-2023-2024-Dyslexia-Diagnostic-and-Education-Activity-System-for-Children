namespace DyslexiaApp.MAUI.Pages.Login;
using DyslexiaApp.MAUI.Pages.Main;
using DyslexiaApp.MAUI.Services;
using DyslexiaApp.MAUI.ViewModels;
using Microsoft.Maui.Controls;
using System.Text.RegularExpressions;
public partial class LoginPage : ContentPage
{
    private readonly AuthService _authService;
	public LoginPage(AuthViewModel authViewModel, AuthService authService)
	{
        InitializeComponent();
        BindingContext = authViewModel;
        _authService = authService;
	}
    protected async override void OnAppearing()
    {
       if(_authService.User is not null  
            && _authService.User.Id!= default(Guid) 
            && !string.IsNullOrWhiteSpace(_authService.Token))
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
    private async void CreateAccountButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Register));
    }
    private async void ForgotPasswordButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ForgotPassword));
    }
}