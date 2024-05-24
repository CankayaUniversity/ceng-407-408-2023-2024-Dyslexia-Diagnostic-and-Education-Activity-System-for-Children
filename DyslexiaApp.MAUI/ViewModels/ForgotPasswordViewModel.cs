using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using DyslexiaApp.MAUI.Services;
using Refit;

public class ForgotPasswordViewModel : INotifyPropertyChanged
{
    private readonly AuthService _authService;
    private string _email;
    private string _message;

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
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

    public ICommand ForgotPasswordCommand { get; }

    public ForgotPasswordViewModel(AuthService authService)
    {
        _authService = authService;
        ForgotPasswordCommand = new Command(async () => await ForgotPasswordAsync());
    }

    private async Task ForgotPasswordAsync()
    {
        try
        {
            var result = await _authService.ForgotPasswordAsync(Email);
            if (result.IsSuccess)
            {
                Message = $"Şifre sıfırlama bağlantınız: {result.Data.ResetLink}";
            }
            else
            {
                Message = $"Şifre sıfırlama talebi başarısız: {result.ErrorMessage}";
            }
        }
        catch (ApiException ex)
        {
            // Hata loglama
            Console.WriteLine($"API Exception: {ex.Message}");
            Message = "Şifre sıfırlama talebi sırasında bir hata oluştu.";
        }
        catch (Exception ex)
        {
            // Genel hata loglama
            Console.WriteLine($"Exception: {ex.Message}");
            Message = "Şifre sıfırlama talebi sırasında bir hata oluştu.";
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}