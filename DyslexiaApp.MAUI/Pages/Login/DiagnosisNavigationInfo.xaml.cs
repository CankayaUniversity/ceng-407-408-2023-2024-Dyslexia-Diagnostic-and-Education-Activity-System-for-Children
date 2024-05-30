using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.ViewModels;

namespace DyslexiaApp.MAUI.Pages.Login;

public partial class DiagnosisNavigationInfo : ContentPage
{
    private readonly NavigationGameViewModel _navigationViewModel;

    public DiagnosisNavigationInfo(NavigationGameViewModel navigationViewModel)
    {
        InitializeComponent();
        _navigationViewModel = navigationViewModel;
        BindingContext = _navigationViewModel; // BindingContext'i ayarlýyoruz
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        _navigationViewModel.Reset(); // ViewModel'i sýfýrlýyoruz
        await _navigationViewModel.InitializeAsync(); // ViewModel'i yeniden baþlatýyoruz
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