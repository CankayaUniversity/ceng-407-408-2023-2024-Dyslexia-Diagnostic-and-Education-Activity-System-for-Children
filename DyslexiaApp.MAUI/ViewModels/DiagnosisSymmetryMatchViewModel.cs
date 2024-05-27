using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.Pages.Login;
using DyslexiaApp.MAUI.Services;
using DyslexiaAppMAUI.Shared.Dtos;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.ViewModels;

public partial class DiagnosisSymmetryMatchViewModel : BaseViewModel
{
    private readonly IEducationalGameListApi _educationalGameListApi;
    private readonly DiagnosisMatchingGamesViewModel _diagnosisMatchingGamesViewModel;
    [ObservableProperty]
    private EducationalDto[] _educational = [];

    private bool _isInitialized;

    [ObservableProperty]
    private EducationalDto selectedGame;

    [ObservableProperty]
    private int currentQuestionIndex; // Use ObservableProperty to automatically implement INotifyPropertyChanged

    public ObservableCollection<QuestionDto> GameQuestions { get; private set; }

    public DiagnosisSymmetryMatchViewModel(IEducationalGameListApi educationalGameListApi, DiagnosisMatchingGamesViewModel diagnosisMatchingGamesViewModel)
    {
        _educationalGameListApi = educationalGameListApi;
        _diagnosisMatchingGamesViewModel = diagnosisMatchingGamesViewModel;
        GameQuestions = new ObservableCollection<QuestionDto>();
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
            SelectedGame = Educational[1];
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

            GameQuestions.Clear();
            foreach (var question in SelectedGame.MatchingGames.SelectMany(mg => mg.Questions))
            {
                GameQuestions.Add(question);
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
    public async Task StartTest()
    {
        Debug.WriteLine($"GameQuestions Count: {GameQuestions.Count}");
        if (GameQuestions == null || GameQuestions.Count == 0)
        {
            await Shell.Current.DisplayAlert("Error", "No questions available.", "OK");
            return;
        }
        Debug.WriteLine($"StartTest Current Question Index: {CurrentQuestionIndex}");
        var firstQuestion = GameQuestions[CurrentQuestionIndex];
        if (firstQuestion != null)
        {
            var route = $"{nameof(SymmetryGameTest)}?questionId={firstQuestion.Id}";
            await Shell.Current.GoToAsync(route);
            Debug.WriteLine($"Navigating to Symmetry with Question ID: {firstQuestion.Id}");
        }
    }

    [RelayCommand]
    public async Task GoToNextQuestion()
    {
        Debug.WriteLine($"GameQuestions Count: {GameQuestions.Count}");
        Debug.WriteLine($"Current Question Index: {CurrentQuestionIndex}");
        if (GameQuestions == null || GameQuestions.Count == 0)
        {
            await Shell.Current.DisplayAlert("Error", "No questions available.", "OK");
            return;
        }

        if (CurrentQuestionIndex < GameQuestions.Count - 1)
        {
            CurrentQuestionIndex++;
            Debug.WriteLine($"Incremented Question Index: {CurrentQuestionIndex}");
            var nextQuestion = GameQuestions[CurrentQuestionIndex];
            Debug.WriteLine($"next with Question ID: {nextQuestion}");
            var route = $"{nameof(SymmetryGameTest)}?questionId={nextQuestion.Id}";
            await Shell.Current.GoToAsync(route);
        }
        else
        {
            Debug.WriteLine($"Answer Results Navigation: {string.Join(", ", _diagnosisMatchingGamesViewModel.AnswerResults)}");
            await Shell.Current.GoToAsync($"//{nameof(DiagnosisResultPage)}");
        }
    }
}