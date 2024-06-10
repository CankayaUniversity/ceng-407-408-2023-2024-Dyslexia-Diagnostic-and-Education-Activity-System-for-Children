namespace DyslexiaApp.MAUI.Pages.Login;
using DyslexiaApp.MAUI.Services;
using DyslexiaApp.MAUI.ViewModels;
using Microsoft.Maui.Controls;
using Refit;
using System.Text.RegularExpressions;

#if ANDROID
using Android.Content.PM;
#endif
public partial class LoginPage : ContentPage
{
    private readonly AuthService _authService;
    private readonly DiagnosisMatchingGamesViewModel _diagnosisMatchingGamesViewModel;

    public LoginPage(AuthViewModel authViewModel, AuthService authService, DiagnosisMatchingGamesViewModel diagnosisMatchingGamesViewModel)
    {
        InitializeComponent();
        BindingContext = authViewModel;
        _authService = authService;
        _diagnosisMatchingGamesViewModel = diagnosisMatchingGamesViewModel;
    }
    private readonly SemaphoreSlim _navigationSemaphore = new SemaphoreSlim(1, 1);

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = OnAppearingAsync();
    }

    private async Task OnAppearingAsync()
    {

        if (_authService.User is not null
            && _authService.User.Id != default(Guid)
            && !string.IsNullOrWhiteSpace(_authService.Token))
        {
            // 500 milisaniye bekleme ekleyerek önceki navigasyon iþlemlerinin tamamlanmasýný bekleyin
            await Task.Delay(500);


            await _diagnosisMatchingGamesViewModel.LoadAllQuestionsAndImages();
            await NavigateToHomePageAsync();
        }
#if ANDROID
               SetOrientation(ScreenOrientation.Portrait);
#endif
    }

    private async Task NavigateToHomePageAsync()
    {
        await _navigationSemaphore.WaitAsync();
        try
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
        finally
        {
            _navigationSemaphore.Release();
        }
    }


    // Navigasyon iþlemleri sýrasýnda kullanýlacak bir kilit nesnesi
    private readonly object _navigationLock = new object();
    private async void CreateAccountButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Register));
    }
    private async void ForgotPasswordButton_Clicked(object sender, EventArgs e)
    {
        var authApi = RestService.For<IAuthApi>("https://localhost:7066");
        var authService = new AuthService(authApi);
        var forgotPasswordViewModel = new ForgotPasswordViewModel(authService);
        var forgotPasswordPage = new ForgotPassword(forgotPasswordViewModel);
        await Navigation.PushModalAsync(forgotPasswordPage);
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        SetBackgroundImage();
    }

    private void SetBackgroundImage()
    {

        if (Width < 500)
        {
            this.BackgroundImageSource = "login_page_mobile.jpg";
        }
        else
        {
            this.BackgroundImageSource = "login.jpg";
        }
    }
#if ANDROID

    private void SetOrientation(ScreenOrientation orientation)
    {
        var activity = Platform.CurrentActivity;
        activity.RequestedOrientation = orientation;
    }
#endif

}