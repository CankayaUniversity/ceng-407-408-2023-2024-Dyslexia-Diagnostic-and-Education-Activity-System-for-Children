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
        private Color _messageColor;
        private string _verificationMessage;

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

        public string VerificationMessage
        {
            get => _verificationMessage;
            set
            {
                _verificationMessage = value;
                OnPropertyChanged();
            }
        }

        public Color MessageColor
        {
            get => _messageColor;
            set
            {
                _messageColor = value;
                OnPropertyChanged();
            }
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
            if (result.IsSuccess)
            {
                Message = "E-Mail send successfully. Check your E-Mail.";
                MessageColor = Colors.Green;
            }
            else
            {
                Message = $"Invalid E-mail address: {result.ErrorMessage}";
                MessageColor = Colors.Red;
            }
            IsVerificationCodeVisible = result.IsSuccess;
        }

        private async Task VerifyCodeAsync()
        {
            var result = await _authService.VerifyCodeAsync(Email, VerificationCode);
            if (result.IsSuccess)
            {
                VerificationMessage = "Verification code sent successfully.";
                MessageColor = Colors.Green;
                await Task.Delay(2000);
                await Shell.Current.GoToAsync($"//ResetPasswordPage?email={Email}&verificationCode={VerificationCode}");
            }
            else
            {
                VerificationMessage = $"Failed to send verification code: {result.ErrorMessage}";
                MessageColor = Colors.Red;
            }
        }

        [RelayCommand]
        public async Task BackToLoginCommand()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
