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
using System.Text.Json;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.ViewModels;

public partial class DiagnosisMatchingGamesViewModel : BaseViewModel
{
    private readonly string _email;
    private readonly IEducationalGameListApi _educationalGameListApi;
    private bool _isDataLoaded = false;
    [ObservableProperty]
    private EducationalDto[] _educational = [];

    private bool _isInitialized;

    [ObservableProperty]
    private bool isPopupVisible;


    [ObservableProperty]
    private EducationalDto selectedGame;

    public ObservableCollection<QuestionDto> GameQuestions { get; private set; }

    public int CurrentQuestionIndex { get; set; }

    // New list to store answer results
    public UserAnswersDto AnswerResults { get; private set; }
    
    public ObservableCollection<ImageDto> GameImages { get; private set; }


    private const int TotalAttempts = 3;
    public int AttemptsRemaining { get; private set; }

    [ObservableProperty]
    private int totalScore = 0;

    public DiagnosisMatchingGamesViewModel(IEducationalGameListApi educationalGameListApi)
    {
        _email = _email = Preferences.Get("UserEmail", string.Empty); ;
        _educationalGameListApi = educationalGameListApi;
        AnswerResults = new UserAnswersDto { AnswerResults = new List<UserAnswerDto>() };

        AttemptsRemaining = TotalAttempts;
        IsPopupVisible = false;

        // Initialize the command
        GoToLetterMatchingGameCommand = new AsyncRelayCommand(GoToLetterMatchingGame);
        GoToSymmetryGameCommand = new AsyncRelayCommand(GoToSymmetryGame);
        GoToPictureGameCommand = new AsyncRelayCommand(GoToPictureGame);
    }

    public IAsyncRelayCommand GoToLetterMatchingGameCommand { get; }
    public IAsyncRelayCommand GoToSymmetryGameCommand { get; }
    public IAsyncRelayCommand GoToPictureGameCommand { get; }

    [ObservableProperty]
    private ObservableCollection<EducationalDto> _filteredEducational = new();

    [ObservableProperty]
    private double accuracyRate;

    [ObservableProperty]
    private string dyslexiaRate;
    public async Task LoadAllQuestionsAndImages()
    {
        if (_isDataLoaded)
            return;

        IsBusy = true;
        try
        {
            _isInitialized = true;
            Educational = await _educationalGameListApi.GetEducationalGamesAsync();
        }
        catch (Exception ex)
        {
            await ShowErrorAlertAsync(ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }

    public void ResetLetter()
    {
        _isInitialized = false;
        SelectedGame = null;
        GameQuestions?.Clear();
        CurrentQuestionIndex = 0;
        //AnswerResults.Clear();
    }

    public void ResetSymmetry()
    {
        _isInitialized = false;
        SelectedGame = null;
        CurrentQuestionIndex = 0;
        GameQuestions.Clear();
        OnPropertyChanged(nameof(SelectedGame));
        OnPropertyChanged(nameof(CurrentQuestionIndex));
        OnPropertyChanged(nameof(GameQuestions));
    }
    public void ResetPopupVisibility()
    {
        IsPopupVisible = false;
    }
    public async Task SelectDefaultGame0()
    {
        if (Educational != null && Educational.Length > 1)
        {
            SelectedGame = Educational[0];
            Debug.WriteLine($"Selected Game: {SelectedGame.Name}");

            SelectedGameStart();
        }
    }

    public async Task SelectDefaultGame1()
    {
        if (Educational != null && Educational.Length > 1)
        {
            SelectedGame = Educational[1];
            Debug.WriteLine($"Selected Game: {SelectedGame.Name}");

            SelectedGameStart();
        }
    }

    public async Task SelectDefaultGame2()
    {
        if (Educational != null && Educational.Length > 1)
        {
            SelectedGame = Educational[2];
            Debug.WriteLine($"Selected Game: {SelectedGame.Name}");
            SelectGame();
            SelectedGameStart();

        }
    }
    private void SelectGame()
    {
        var game = SelectedGame;
        if (game != null)
        {
            FilteredEducational.Clear();
            FilteredEducational.Add(game);
        }
        Debug.WriteLine($"Selected Game in Slct: {SelectedGame.Name}");

    }
    public void SelectedGameStart()
    {
        Debug.WriteLine("in");
        if (SelectedGame != null)
        {
            Debug.WriteLine($"Selected Game: {SelectedGame.Name}");
            Debug.WriteLine($"Description: {SelectedGame.Description}");
            Debug.WriteLine($"Id: {SelectedGame.Id}");

            GameQuestions = new ObservableCollection<QuestionDto>(
                SelectedGame.MatchingGames.SelectMany(mg => mg.Questions).ToList());


            // Initialize the GameImages collection
            GameImages = new ObservableCollection<ImageDto>(
                GameQuestions
                    .SelectMany(q =>
                        new[] { q.MainImage }
                        .Concat(q.ImageOptions ?? new List<ImageDto>())
                    ).Where(img => img != null).ToList());


            foreach (var question in GameQuestions)
            {
                Debug.WriteLine($"Question ID: {question.Id}");
            }
            foreach (var image in GameImages)
            {
                Debug.WriteLine($"Image ID: {image.Id}");
            }
        }
        else
        {
            Debug.WriteLine("null");
        }
        CurrentQuestionIndex = 0;

    }
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
            Debug.WriteLine($"Letter Matching In: {selectedQuestion.Id}");

            try
            {

                var questionJson = JsonSerializer.Serialize(selectedQuestion);
                var route = $"{nameof(LetterMatchingGame)}?questionJson={Uri.EscapeDataString(questionJson)}";
                await Shell.Current.GoToAsync(route);

                Debug.WriteLine($"Navigating to LetterMatchingGame with Question ID: {selectedQuestion.Id}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error serializing question: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Failed to serialize question.", "OK");
            }
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

            var nextQuestionJson = JsonSerializer.Serialize(nextQuestion);
            var route = $"{nameof(LetterMatchingGame)}?questionJson={Uri.EscapeDataString(nextQuestionJson)}";
            await Shell.Current.GoToAsync(route);
        }
        else
        {
            Debug.WriteLine($"Answer Results: {String.Join(", ", AnswerResults)}");
            await Shell.Current.GoToAsync($"//{nameof(DiagnosisNavigationInfo)}");
        }
    }

    public async Task GoToSymmetryGame()
    {
        if (GameQuestions == null || GameQuestions.Count == 0)
        {
            await Shell.Current.DisplayAlert("Error", "No questions available.", "OK");
            return;
        }

        var selectedQuestion = GameQuestions[CurrentQuestionIndex];

        if (selectedQuestion != null)
        {
            Debug.WriteLine($"Letter Matching In: {selectedQuestion.Id}");

            try
            {

                var questionJson = JsonSerializer.Serialize(selectedQuestion);
                var route = $"{nameof(SymmetryGameTest)}?questionJson={Uri.EscapeDataString(questionJson)}";
                await Shell.Current.GoToAsync(route);

                Debug.WriteLine($"Navigating to LetterMatchingGame with Question ID: {selectedQuestion.Id}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error serializing question: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Failed to serialize question.", "OK");
            }
        }
    }

    [RelayCommand]
    public async Task GoToNextSymmetryQuestion()
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

            var nextQuestionJson = JsonSerializer.Serialize(nextQuestion);
            var route = $"{nameof(SymmetryGameTest)}?questionJson={Uri.EscapeDataString(nextQuestionJson)}";
            await Shell.Current.GoToAsync(route);
        }
        else
        {

            var result = await SubmitAnswersAsync(_email);

            if (result != null)
            {
                Debug.WriteLine($"Result: {result.DyslexiaRate}");
                Debug.WriteLine($"Result: {result.AccuracyRate * 100}");

            }

            accuracyRate = result.AccuracyRate;
            dyslexiaRate = result.DyslexiaRate;
            await Shell.Current.GoToAsync($"//{nameof(DiagnosisResultPage)}");
            Debug.WriteLine($"Answer Results: {String.Join(", ", AnswerResults)}");
            await Shell.Current.GoToAsync($"//{nameof(DiagnosisResultPage)}");
        }
    }
    [RelayCommand]
    public void ShowGameDetails()
    {
        if (SelectedGame != null)
        {

            Debug.WriteLine($"Game Selected: {SelectedGame.Name}");
            Debug.WriteLine($"Description: {SelectedGame.Description}");
            Debug.WriteLine($"ID: {SelectedGame.Id}");

            GameQuestions = new ObservableCollection<QuestionDto>(
                SelectedGame.MatchingGames.SelectMany(mg => mg.Questions).ToList());

            GameImages = new ObservableCollection<ImageDto>(
                 GameQuestions
                     .SelectMany(q =>
                         new[] { q.MainImage }
                         .Concat(q.ImageOptions ?? new List<ImageDto>())
                     ).Where(img => img != null).ToList());


            foreach (var question in GameQuestions)
            {
                Debug.WriteLine($"Question ID: {question.Id}");
            }
            foreach (var image in GameImages)
            {
                Debug.WriteLine($"Image ID: {image.Id}");
            }

            AttemptsRemaining = TotalAttempts;

            CurrentQuestionIndex = 0;
            IsPopupVisible = true;
        }
        else
        {
            Debug.WriteLine("null education list");
        }
    }

    public async Task GoToPictureGame()
    {
        if (GameQuestions == null || GameQuestions.Count == 0)
        {
            await Shell.Current.DisplayAlert("Error", "No questions available.", "OK");
            return;
        }

        var selectedQuestion = GameQuestions[CurrentQuestionIndex];

        if (selectedQuestion != null)
        {
            Debug.WriteLine($"Letter Matching In: {selectedQuestion.Id}");

            try
            {

                var questionJson = JsonSerializer.Serialize(selectedQuestion);
                var route = $"{nameof(PlayGame)}?questionJson={Uri.EscapeDataString(questionJson)}";
                await Shell.Current.GoToAsync(route);

                Debug.WriteLine($"Navigating to LetterMatchingGame with Question ID: {selectedQuestion.Id}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error serializing question: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Failed to serialize question.", "OK");
            }
        }
    }

    [RelayCommand]
    public async Task GoToNextPictureQuestion()
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

            var nextQuestionJson = JsonSerializer.Serialize(nextQuestion);
            var route = $"{nameof(PlayGame)}?questionJson={Uri.EscapeDataString(nextQuestionJson)}";
            await Shell.Current.GoToAsync(route);
        }
        else
        {
            Debug.WriteLine($"Answer Results: {String.Join(", ", AnswerResults)}");
            await Shell.Current.GoToAsync($"//{nameof(EducationalResultPage)}");
        }
    }
    public void DecreaseAttempts()
    {
        if (AttemptsRemaining > 0)
        {
            AttemptsRemaining--;
        }
    }

    public void IncreaseTotalScore(int amount)
    {
        TotalScore += amount;
    }

    public void DecreaseTotalScore(int amount)
    {
        TotalScore -= amount;
    }

    [RelayCommand]
    private void ClosePopup()
    {
        IsPopupVisible = false;
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