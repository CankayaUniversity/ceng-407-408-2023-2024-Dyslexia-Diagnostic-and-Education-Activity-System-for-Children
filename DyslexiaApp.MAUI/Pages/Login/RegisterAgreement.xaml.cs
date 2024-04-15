namespace DyslexiaApp.MAUI.Pages.Login;
using DyslexiaApp.MAUI.ViewModels;
using DyslexiaAppMAUI.Shared.Dtos;

public partial class RegisterAgreement : ContentPage
{
    public RegisterAgreement(AuthViewModel authViewModel)
    {
        InitializeComponent();
        BindingContext = authViewModel;
    }

    private async void OnCloseButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(Register)}");
    }
    private async void OnRegisterAgreementButtonClicked(object sender, EventArgs e)
    {
        if (AgreementCheckBox.IsChecked)
        {
            if (BindingContext is AuthViewModel authViewModel)
            {
                IsBusy = true;
                try
                {
                    var signupRequest = new SignupRequestDto(
                        authViewModel.FirstName,
                        authViewModel.LastName,
                        authViewModel.Gender,
                        authViewModel.Email,
                        authViewModel.Password,
                        authViewModel.Birthdate);

                    var success = await authViewModel.TrySignupAsync(signupRequest);

                    if (success)
                    {
                        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                    }
                    else
                    {
                        await DisplayAlert("Error", "Signup failed", "OK");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "OK");
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }
        else
        {
            await DisplayAlert("Warning", "You must agree to the terms and conditions before registering.", "OK");
        }
    }

}