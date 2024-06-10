namespace DyslexiaApp.MAUI.Pages.Login;
using DyslexiaApp.MAUI.ViewModels;

#if ANDROID
using Android.Content.PM;
#endif
public partial class Register : ContentPage
{
    public Register(AuthViewModel authViewModel)
    {
        InitializeComponent();
        BindingContext = authViewModel;
    }
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

#if ANDROID

    private void SetOrientation(ScreenOrientation orientation)
    {
    var activity = Platform.CurrentActivity;
       activity.RequestedOrientation = orientation;
    }
#endif


#if ANDROID
    protected override void OnAppearing()
    {
    SetOrientation(ScreenOrientation.Portrait);
    }
#endif

}
