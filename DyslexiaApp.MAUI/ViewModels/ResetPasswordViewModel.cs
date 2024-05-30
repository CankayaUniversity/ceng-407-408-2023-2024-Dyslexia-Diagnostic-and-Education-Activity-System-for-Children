using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.Services;

namespace DyslexiaApp.MAUI.ViewModels;

public class ResetPasswordViewModel : BaseViewModel
{
    private readonly AuthService _authService;
    private string _verificationCode;
    private string _email;
    private string _newPassword;
    private string _message;

    public string VerificationCode
    {
        get => _verificationCode;
        set
        {
            _verificationCode = value;
            OnPropertyChanged();
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged();
        }
    }

    public string NewPassword
    {
        get => _newPassword;
        set
        {
            _newPassword = value;
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

    public ICommand ResetPasswordCommand { get; }

    public ResetPasswordViewModel(AuthService authService)
    {
        _authService = authService;
        ResetPasswordCommand = new AsyncRelayCommand(ResetPasswordAsync);
    }

    private async Task ResetPasswordAsync()
    {
        var result = await _authService.ResetPasswordAsync(VerificationCode, Email, NewPassword);
        Message = result.IsSuccess ? "Failed to reset password" : $"Password reset successfully.";
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
