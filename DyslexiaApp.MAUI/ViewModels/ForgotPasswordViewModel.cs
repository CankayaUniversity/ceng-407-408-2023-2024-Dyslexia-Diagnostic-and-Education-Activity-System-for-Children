using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using DyslexiaApp.MAUI.Services;
using DyslexiaAppMAUI.Shared.Dtos;
using DyslexiaApp.MAUI.Pages.Login;

public class ForgotPasswordViewModel : INotifyPropertyChanged
{
    private readonly AuthService _authService;
    private string _email;
    private string _verificationCode;
    private string _message;
    private bool _isVerificationCodeVisible;

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged();
        }
    }

    public string VerificationCode
    {
        get => _verificationCode;
        set
        {
            _verificationCode = value;
            OnPropertyChanged();
        }
    }

    public string Message
    {
        get => _message;
        set
        {
            _message = value;
            OnPropertyChanged();
        }
    }

    public bool IsVerificationCodeVisible
    {
        get => _isVerificationCodeVisible;
        set
        {
            _isVerificationCodeVisible = value;
            OnPropertyChanged();
        }
    }

    public ICommand SendCodeCommand { get; }
    public ICommand VerifyCodeCommand { get; }

    public ForgotPasswordViewModel(AuthService authService)
    {
        _authService = authService;
        SendCodeCommand = new Command(async () => await SendCodeAsync());
        VerifyCodeCommand = new Command(async () => await VerifyCodeAsync());
        IsVerificationCodeVisible = false;
    }

    private async Task SendCodeAsync()
    {
        var result = await _authService.SendVerificationCodeAsync(Email);
        Message = result.IsSuccess ? "Verification code sent successfully." : $"Failed to send verification code: {result.ErrorMessage}";
        IsVerificationCodeVisible = result.IsSuccess;
    }

    private async Task VerifyCodeAsync()
    {
        var result = await _authService.VerifyCodeAsync(Email, VerificationCode);
        Message = result.IsSuccess ? "Code verified successfully. Proceed to reset password." : $"Invalid verification code: {result.ErrorMessage}";
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
