using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.Pages.Login;
using DyslexiaApp.MAUI.Services;
using DyslexiaAppMAUI.Shared;
using DyslexiaAppMAUI.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.ViewModels;

public partial class DiagnosisMatchingGamesViewModel : BaseViewModel
{
    private readonly IEducationalGameListApi _educationalGameListApi;

    [ObservableProperty]
    private EducationalDto[] _educational = [];

    private bool _isInitialized;

    [ObservableProperty]
    private EducationalDto selectedGame;

    public ObservableCollection<QuestionDto> GameQuestions { get; private set; }

    public int CurrentQuestionIndex { get; set; }

    // New list to store answer results
    public UserAnswersDto AnswerResults { get; private set; }

    public DiagnosisMatchingGamesViewModel(IEducationalGameListApi educationalGameListApi)
    {
        _educationalGameListApi = educationalGameListApi;
        AnswerResults = new UserAnswersDto { AnswerResults = new List<UserAnswerDto>() };
    }

    public async Task InitializeAsync()
    {
        if (_isInitialized)
            return;
        IsBusy = true;

        try
        {
            _isInitialized = true;
            Educational = await _educationalGameListApi.GetEducationalGamesAsync();
            SelectDefaultGame();
        }
        catch (Exception ex)
        {
            _isInitialized = false;
            await ShowErrorAlertAsync(ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }

    private void SelectDefaultGame()
    {
        if (Educational != null && Educational.Length > 1)
        {
            SelectedGame = Educational[0];
            Debug.WriteLine($"Selected Game: {SelectedGame.Name}");

            SelectedGameStart();
        }
    }

    public void SelectedGameStart()
    {
        Debug.WriteLine("in");
        if (SelectedGame != null)
        {
            Debug.WriteLine($"Selected Game: {SelectedGame.Name}");
            Debug.WriteLine($"Description: {SelectedGame.Description}");
            Debug.WriteLine($"Description: {SelectedGame.Id}");

            GameQuestions = new ObservableCollection<QuestionDto>(
                SelectedGame.MatchingGames.SelectMany(mg => mg.Questions).ToList());

            foreach (var question in GameQuestions)
            {
                Debug.WriteLine($"Question ID: {question.Id}");
            }
            CurrentQuestionIndex = 0;
        }
        else
        {
            Debug.WriteLine("null");
        }
    }

    [RelayCommand]
    public async Task GoToLetterMatchingGame()
    {
        if (GameQuestions == null || GameQuestions.Count == 0)
        {
            await Shell.Current.DisplayAlert("Error", "No questions available.", "OK");
            return;
        }

        var selectedQuestion = GameQuestions[CurrentQuestionIndex];
        if (selectedQuestion != null)
        {
            var route = $"{nameof(LetterMatchingGame)}?questionId={selectedQuestion.Id}";
            await Shell.Current.GoToAsync(route);
            Debug.WriteLine($"Navigating to PictureMatchingGame with Question ID: {selectedQuestion.Id}");
        }
    }

    [RelayCommand]
    public async Task GoToNextQuestion()
    {
        if (GameQuestions == null || GameQuestions.Count == 0)
        {
            await Shell.Current.DisplayAlert("Error", "No questions available.", "OK");
            return;
        }

        if (CurrentQuestionIndex < GameQuestions.Count - 1)
        {
            CurrentQuestionIndex++;
            var nextQuestion = GameQuestions[CurrentQuestionIndex];
            Debug.WriteLine($"Next Question ID: {nextQuestion.Id}");
            var route = $"{nameof(LetterMatchingGame)}?questionId={nextQuestion.Id}";
            await Shell.Current.GoToAsync(route);
        }
        else
        {
            // Shell.Current.DisplayAlert("End of Game", "You have completed all questions in this test. Go to next Test.", "OK");

            Debug.WriteLine($"Answer Results: {String.Join(", ", AnswerResults)}");

            await Shell.Current.GoToAsync($"//{nameof(DiagnosisNavigationInfo)}");
        }
    }

    public async Task<DyslexiaResultDto> SubmitAnswersAsync(string email)
    {
        try
        {
            var result = await _educationalGameListApi.SubmitAnswersAsync(AnswerResults,email);
            Debug.WriteLine($"Result= {result}");
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error submitting answers: {ex.Message}");
            return null;
        }
    }
}