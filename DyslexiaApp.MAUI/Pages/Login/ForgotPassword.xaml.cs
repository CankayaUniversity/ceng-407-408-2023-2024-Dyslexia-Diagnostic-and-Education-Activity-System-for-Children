namespace DyslexiaApp.MAUI.Pages.Login;
using System.Text.RegularExpressions;
public partial class ForgotPassword : ContentPage
{
	public ForgotPassword()
	{
		InitializeComponent();
	}

    private async void OnCloseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    public bool IsValidEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(email);
    }

    private async void EmailEntry_Unfocused(object sender, FocusEventArgs e)
    {
        string email = emailEntry.Text;

        if (!IsValidEmail(email))
        {
            await DisplayAlert("Error", "Please enter a valid email address.", "OK");
            emailEntry.Focus();
        }
    }

    private async void OnSendEmailButtonClicked(object sender, EventArgs e)
    {
        // E-posta alan�n� kontrol et
        //string email = emailEntry.Text;
        //if (string.IsNullOrWhiteSpace(email))
        //{
        //    await DisplayAlert("Error", "Please enter your email address.", "OK");
        //    return;
        //}

        //// E-posta format�n� kontrol et
        //if (!IsValidEmail(email))
        //{
        //    await DisplayAlert("Error", "Please enter a valid email address.", "OK");
        //    return;
        //}

        string enteredCode = null;
        while (string.IsNullOrEmpty(enteredCode))
        {
            // 6 haneli kodu almak i�in bir giri� kutusu g�ster
            enteredCode = await DisplayPromptAsync("Enter Code", "Please enter the 6-digit code sent to your email", "OK", "Cancel", maxLength: 6, keyboard: Keyboard.Numeric);

            // Kullan�c� iptal ederse
            if (enteredCode == null)
            {
                return; // ��lemi sonland�r
            }

            // Kullan�c� iptal etmezse ve bo� bir de�er girerse
            if (string.IsNullOrWhiteSpace(enteredCode))
            {
                await DisplayAlert("Error", "Code cannot be empty. Please try again.", "OK");
            }
            else
            {
                // Giri�in tam olarak 6 haneli olup olmad���n� kontrol et
                if (enteredCode.Length != 6)
                {
                    await DisplayAlert("Error", "Please enter a 6-digit code.", "OK");
                    enteredCode = null; // Girilen kodu temizle ve tekrar giri� yap�lmas�n� sa�la
                }
                else
                {
                    // Giri�in sadece say�sal de�erler i�erip i�ermedi�ini kontrol et
                    if (!int.TryParse(enteredCode, out _))
                    {
                        await DisplayAlert("Error", "Please enter only numeric digits.", "OK");
                        enteredCode = null; // Girilen kodu temizle ve tekrar giri� yap�lmas�n� sa�la
                    }
                }
            }
            //attemptCount++;
            //if (attemptCount >= maxAttempts)
            //{
            //    await DisplayAlert("Error", "You have exceeded the maximum number of attempts.", "OK");
            //    return; // ��lemi sonland�r
            //}

        }
    }
}