#if ANDROID
using Android.Content.PM;
#endif
using DyslexiaApp.MAUI.Services;
using DyslexiaApp.MAUI.ViewModels;

namespace DyslexiaApp.MAUI.Pages.Login;

public partial class HomePage : ContentPage
{
    private readonly ChatViewModel _chatViewModel;
    private readonly AuthService _authService;

    public HomePage(ChatViewModel chatViewModel, AuthService authService)
    {
        InitializeComponent();
        _chatViewModel = chatViewModel;
        _authService = authService;
        BindingContext = _chatViewModel;

    }
    private async void SignoutMenuItem_Clicked(object sender, EventArgs e)
    {
        _authService.Signout();
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    private async void DiagnosisTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(DiagnosticTestAgreement)}");
    }
    private async void EducationalTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(EducationalGameList)}");
    }

    private async void OnProfileTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(ProfilePage)}"); ;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
#if ANDROID
        SetOrientation(ScreenOrientation.Landscape);
#endif

    }


#if ANDROID

    private void SetOrientation(ScreenOrientation orientation)
    {
        var activity = Platform.CurrentActivity;
        activity.RequestedOrientation = orientation;
    }
#endif
}