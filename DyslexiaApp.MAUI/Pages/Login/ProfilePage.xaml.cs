using DyslexiaApp.MAUI.Services;
using DyslexiaApp.MAUI.ViewModels;

namespace DyslexiaApp.MAUI.Pages.Login;

public partial class ProfilePage : ContentPage
{
    private AuthService _authService;
    private readonly ProfileViewModel _profileViewModel;

    public ProfilePage(AuthService authService, ProfileViewModel profileViewModel)
    {
        InitializeComponent();
        _authService = authService;
        _profileViewModel = profileViewModel;
        BindingContext = profileViewModel;
    }

    protected async override void OnAppearing()
    {
        await _profileViewModel.InitializeAsync();
    }

    private async void Close_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
    private async void SignoutMenuItem_Clicked(object sender, EventArgs e)
    {
        _authService.Signout();
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}