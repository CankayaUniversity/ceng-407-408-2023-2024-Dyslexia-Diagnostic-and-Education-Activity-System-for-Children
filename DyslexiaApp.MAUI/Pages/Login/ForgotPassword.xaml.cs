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
        // E-posta alanýný kontrol et
        //string email = emailEntry.Text;
        //if (string.IsNullOrWhiteSpace(email))
        //{
        //    await DisplayAlert("Error", "Please enter your email address.", "OK");
        //    return;
        //}

        //// E-posta formatýný kontrol et
        //if (!IsValidEmail(email))
        //{
        //    await DisplayAlert("Error", "Please enter a valid email address.", "OK");
        //    return;
        //}

        string enteredCode = null;
        while (string.IsNullOrEmpty(enteredCode))
        {
            // 6 haneli kodu almak için bir giriþ kutusu göster
            enteredCode = await DisplayPromptAsync("Enter Code", "Please enter the 6-digit code sent to your email", "OK", "Cancel", maxLength: 6, keyboard: Keyboard.Numeric);

            // Kullanýcý iptal ederse
            if (enteredCode == null)
            {
                return; // Ýþlemi sonlandýr
            }

            // Kullanýcý iptal etmezse ve boþ bir deðer girerse
            if (string.IsNullOrWhiteSpace(enteredCode))
            {
                await DisplayAlert("Error", "Code cannot be empty. Please try again.", "OK");
            }
            else
            {
                // Giriþin tam olarak 6 haneli olup olmadýðýný kontrol et
                if (enteredCode.Length != 6)
                {
                    await DisplayAlert("Error", "Please enter a 6-digit code.", "OK");
                    enteredCode = null; // Girilen kodu temizle ve tekrar giriþ yapýlmasýný saðla
                }
                else
                {
                    // Giriþin sadece sayýsal deðerler içerip içermediðini kontrol et
                    if (!int.TryParse(enteredCode, out _))
                    {
                        await DisplayAlert("Error", "Please enter only numeric digits.", "OK");
                        enteredCode = null; // Girilen kodu temizle ve tekrar giriþ yapýlmasýný saðla
                    }
                }
            }
            //attemptCount++;
            //if (attemptCount >= maxAttempts)
            //{
            //    await DisplayAlert("Error", "You have exceeded the maximum number of attempts.", "OK");
            //    return; // Ýþlemi sonlandýr
            //}

        }
    }
}