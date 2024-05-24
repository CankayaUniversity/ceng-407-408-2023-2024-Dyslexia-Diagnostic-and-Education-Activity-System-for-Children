using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using DyslexiaApp.MAUI.Services;

public class ResetPasswordViewModel : INotifyPropertyChanged
{
    private readonly AuthService _authService;
    private string _token;
    private string _email;
    private string _newPassword;
    private string _message;

    public string Token
    {
        get => _token;
        set
        {
            _token = value;
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
        ResetPasswordCommand = new Command(async () => await ResetPasswordAsync());
    }

    private async Task ResetPasswordAsync()
    {
        var result = await _authService.ResetPasswordAsync(Token, Email, NewPassword);
        Message = result ? "Password reset successfully." : "Failed to reset password.";
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
