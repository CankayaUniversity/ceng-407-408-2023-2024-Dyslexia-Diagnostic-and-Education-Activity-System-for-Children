using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.Services;
using DyslexiaApp.MAUI.ViewModels;
using Microsoft.Maui.Controls;
using System.Diagnostics;
namespace DyslexiaApp.MAUI.Pages.Login;

[QueryProperty(nameof(Email), "email")]
[QueryProperty(nameof(VerificationCode), "verificationCode")]
public partial class ResetPasswordPage : ContentPage
{
    private readonly AuthService _authService;
    private readonly ResetPasswordViewModel _viewModel;

    private string email;
    public string Email
    {
        get => email;
        set
        {
            email = value;
            Debug.WriteLine($"Email set to: {email}");
            if (BindingContext is ResetPasswordViewModel viewModel)
            {
                viewModel.Email = email;
            }
        }
    }

    private string verificationCode;
    public string VerificationCode
    {
        get => verificationCode;
        set
        {
            verificationCode = value;
            Debug.WriteLine($"VerificationCode set to: {verificationCode}");
            if (BindingContext is ResetPasswordViewModel viewModel)
            {
                viewModel.VerificationCode = verificationCode;
            }
        }
    }

    public ResetPasswordPage(ResetPasswordViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Ensure properties are correctly set when the page appears
        if (BindingContext is ResetPasswordViewModel viewModel)
        {
            viewModel.Email = Email;
            viewModel.VerificationCode = VerificationCode;
        }
    }

    private async void OnResetPasswordClicked(object sender, EventArgs e)
    {
        if (BindingContext is ResetPasswordViewModel viewModel)
        {
            string confirmPassword = ConfirmPasswordEntry.Text;

            if (string.IsNullOrEmpty(viewModel.NewPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                FeedbackLabel.Text = "Please fill in both fields.";
                FeedbackLabel.IsVisible = true;
                return;
            }

            if (viewModel.NewPassword != confirmPassword)
            {
                FeedbackLabel.Text = "Passwords do not match.";
                FeedbackLabel.IsVisible = true;
                return;
            }

            // Execute the reset password command
            await ((AsyncRelayCommand)viewModel.ResetPasswordCommand).ExecuteAsync(null);

            // Update the feedback label based on the result
            FeedbackLabel.TextColor = viewModel.Message.Contains("success") ? Microsoft.Maui.Graphics.Colors.Green : Microsoft.Maui.Graphics.Colors.Red;
            FeedbackLabel.Text = viewModel.Message;
            FeedbackLabel.IsVisible = true;
        }
    }

    private async void OnBackToLoginClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }
}
