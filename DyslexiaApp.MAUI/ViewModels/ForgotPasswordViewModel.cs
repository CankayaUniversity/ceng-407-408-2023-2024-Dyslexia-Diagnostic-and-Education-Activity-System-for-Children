using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.Pages.Login;
using DyslexiaApp.MAUI.Services;
using DyslexiaAppMAUI.Shared.Dtos;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DyslexiaApp.MAUI.ViewModels
{
    public partial class ForgotPasswordViewModel : ObservableObject
    {
        private readonly AuthService _authService;
        private string _email;
        private string _verificationCode;
        private string _message;
        private bool _isVerificationCodeVisible;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string VerificationCode
        {
            get => _verificationCode;
            set => SetProperty(ref _verificationCode, value);
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public bool IsVerificationCodeVisible
        {
            get => _isVerificationCodeVisible;
            set => SetProperty(ref _isVerificationCodeVisible, value);
        }

        public ICommand SendCodeCommand { get; }
        public ICommand VerifyCodeCommand { get; }

        public ForgotPasswordViewModel(AuthService authService)
        {
            _authService = authService;
            SendCodeCommand = new AsyncRelayCommand(SendCodeAsync);
            VerifyCodeCommand = new AsyncRelayCommand(VerifyCodeAsync);
            IsVerificationCodeVisible = false;
        }

        private async Task SendCodeAsync()
        {
            var result = await _authService.SendVerificationCodeAsync(Email);
            Message = result.IsSuccess ? "Verification code sent successfully." : $"Failed to send verification code: {result.ErrorMessage}";
            IsVerificationCodeVisible = result.IsSuccess; // This should update the visibility of the verification code section
        }

        private async Task VerifyCodeAsync()
        {
            var result = await _authService.VerifyCodeAsync(Email, VerificationCode);
            Message = result.IsSuccess ? "Code verified successfully. Proceed to reset password." : $"Invalid verification code: {result.ErrorMessage}";
            if (result.IsSuccess)
            {
                await Shell.Current.GoToAsync($"//ResetPasswordPage?email={Email}&verificationCode={VerificationCode}");
            }
        }

        [RelayCommand]
        public async Task BackToLoginCommand()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
