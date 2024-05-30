using DyslexiaApp.MAUI.ViewModels;
using DyslexiaAppMAUI.Shared.Dtos;
using Microsoft.Maui;
using System;
using System.Diagnostics;
using System.Text.Json;

namespace DyslexiaApp.MAUI.Pages.Login;


[QueryProperty(nameof(QuestionJson), "questionJson")]
public partial class PlayGame : ContentPage
{
    private readonly MatchingViewModel _matchingViewModel;
    private readonly DiagnosisMatchingGamesViewModel _diagnosisMatchingGamesViewModel;
    public string QuestionJson { get; set; }
    public PlayGame(MatchingViewModel matchingViewModel, DiagnosisMatchingGamesViewModel diagnosisMatchingGamesViewModel)
    {
        InitializeComponent();
        _matchingViewModel = matchingViewModel;
        _diagnosisMatchingGamesViewModel = diagnosisMatchingGamesViewModel;
        BindingContext = _matchingViewModel;

        NextButton.Command = new Command(_matchingViewModel.GoToNextQuestion);

        _matchingViewModel.AttemptsRemaining = _diagnosisMatchingGamesViewModel.AttemptsRemaining;
        _matchingViewModel.DecreaseAttempts = _diagnosisMatchingGamesViewModel.DecreaseAttempts;

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (!string.IsNullOrEmpty(QuestionJson))
        {
            await LoadQuestionData(QuestionJson);
        }
    }

    private async Task LoadQuestionData(string questionJson)
    {
        try
        {
            var question = JsonSerializer.Deserialize<QuestionDto>(questionJson);
            if (question != null)
            {
                await _matchingViewModel.InitializeAsync(question); // Initialize the ViewModel with the question
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deserializing question: {ex.Message}");
            await DisplayAlert("Error", "Failed to load question.", "OK");
        }
    }

    private async void Home_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}