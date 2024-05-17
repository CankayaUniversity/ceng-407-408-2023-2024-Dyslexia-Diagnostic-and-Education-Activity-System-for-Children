using DyslexiaApp.MAUI.ViewModels;
using DyslexiaAppMAUI.Shared.Dtos;
using Microsoft.Maui;
using System;
using System.Diagnostics;

namespace DyslexiaApp.MAUI.Pages.Login;

[QueryProperty(nameof(QuestionId), "questionId")]
public partial class PlayGame : ContentPage
{
    private readonly MatchingViewModel _matchingViewModel;
    private EducationalGamesViewModel _educationalViewModel;

    private string _questionId;
    public string QuestionId
    {
        get => _questionId;
        set
        {
            _questionId = Uri.UnescapeDataString(value ?? string.Empty);
            Debug.WriteLine($"Game Selected: {_questionId}");
            LoadQuestionData(_questionId);
        }
    }

    public PlayGame(MatchingViewModel matchingViewModel, EducationalGamesViewModel educationalViewModel)
    {
        InitializeComponent();
        _matchingViewModel = matchingViewModel;
        _educationalViewModel = educationalViewModel;
        BindingContext = _matchingViewModel;

        NextButton.Command = new Command(async () => await _educationalViewModel.GoToNextQuestion());
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