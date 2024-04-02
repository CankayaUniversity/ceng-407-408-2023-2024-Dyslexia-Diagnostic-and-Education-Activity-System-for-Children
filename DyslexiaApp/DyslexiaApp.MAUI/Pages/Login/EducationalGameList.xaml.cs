namespace DyslexiaApp.MAUI.Pages.Login;

public partial class EducationalGameList : ContentPage
{
	public EducationalGameList()
	{
		InitializeComponent();
	}

    private async void Close_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }


}