namespace DyslexiaApp.MAUI.Pages.Login;
using DyslexiaApp.MAUI.ViewModels;
using DyslexiaAppMAUI.Shared.Dtos;
using Microsoft.Maui;
using System.Diagnostics;

[QueryProperty(nameof(QuestionId), "questionId")]
public partial class PlayGame : ContentPage
{
    private readonly PictureMatchingViewModel _matchingViewModel;
    private EducationalGamesViewModel _educationalViewModel;


    private string _questionId;
    public string QuestionId
    {
        get => _questionId;
        set
        {
            _questionId = Uri.UnescapeDataString(value ?? string.Empty);
            LoadQuestionData(_questionId);
        }
    }
    public PlayGame(PictureMatchingViewModel matchingViewModel, EducationalGamesViewModel educationalViewModel)
    {
        InitializeComponent();
        _matchingViewModel = matchingViewModel;
        _educationalViewModel = educationalViewModel;
        BindingContext = _matchingViewModel;

        NextButton.Command = new Command(() => _educationalViewModel.GoToNextQuestion());
    }

    private async void LoadQuestionData(string questionId)
    {
        if (Guid.TryParse(questionId, out Guid id))
        {
            await _matchingViewModel.InitializeAsync(id);
        }
    }

    private async void Home_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}