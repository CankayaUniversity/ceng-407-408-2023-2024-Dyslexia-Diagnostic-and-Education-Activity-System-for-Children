using DyslexiaApp.MAUI.ViewModels;

namespace DyslexiaApp.MAUI.Pages.Login;

[QueryProperty(nameof(Email), "email")]
[QueryProperty(nameof(VerificationCode), "verificationCode")]
public partial class ResetPasswordPage : ContentPage
{
    public string Email { get; set; }
    public string VerificationCode { get; set; }

    public ResetPasswordPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is ResetPasswordViewModel viewModel)
        {
            viewModel.Email = Email;
            viewModel.VerificationCode = VerificationCode;
        }
    }
}