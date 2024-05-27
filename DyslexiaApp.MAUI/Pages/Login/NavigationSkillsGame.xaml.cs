using DyslexiaApp.MAUI.ViewModels;

namespace DyslexiaApp.MAUI.Pages.Login;

public partial class NavigationSkillsGame : ContentPage
{
    private readonly NavigationGameViewModel _navigationGameViewModel;
    private readonly DiagnosisMatchingGamesViewModel _diagnosisMatchingGamesViewModel;

    public NavigationSkillsGame(NavigationGameViewModel navigationGameViewModel, DiagnosisMatchingGamesViewModel diagnosisMatchingGamesViewModel)
    {
        InitializeComponent();
        _navigationGameViewModel = navigationGameViewModel;
        _diagnosisMatchingGamesViewModel = diagnosisMatchingGamesViewModel;
        BindingContext = _navigationGameViewModel;

        LoadQuestionData();
    }

    private async void LoadQuestionData()
    {
        await _navigationGameViewModel.InitializeAsync();
    }

    private async void Home_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}