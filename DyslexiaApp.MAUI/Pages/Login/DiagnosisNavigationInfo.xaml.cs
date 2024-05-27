using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.ViewModels;

namespace DyslexiaApp.MAUI.Pages.Login;

public partial class DiagnosisNavigationInfo : ContentPage
{
    public DiagnosisNavigationInfo()
    {
        InitializeComponent();
    }

    private async void GoToNavigationGame(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(NavigationSkillsGame)}");
    }

    private async void Close_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }

}