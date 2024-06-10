#if ANDROID
using Android.Content.PM;
#endif

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
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        else
        {
            await DisplayAlert("Warning", "You must agree to the terms and conditions before registering.", "OK");
        }

    }
#if ANDROID

    private void SetOrientation(ScreenOrientation orientation)
    {
        var activity = Platform.CurrentActivity;
        activity.RequestedOrientation = orientation;
    }
#endif
    protected override void OnAppearing()
    {
        base.OnAppearing();
#if ANDROID
        SetOrientation(ScreenOrientation.Portrait);
#endif
    }
}