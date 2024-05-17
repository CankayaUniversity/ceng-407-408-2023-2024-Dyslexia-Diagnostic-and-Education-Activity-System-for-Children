using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.Pages.Login;
using DyslexiaApp.MAUI.Services;
using DyslexiaAppMAUI.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.ObjectModel;


namespace DyslexiaApp.MAUI.ViewModels;

public partial class EducationalGamesViewModel : BaseViewModel
{
    private readonly IEducationalGameListApi _educationalGameListApi;

    [ObservableProperty]
    private EducationalDto[] _educational = [];

    private bool _isInitialized;

    [ObservableProperty]
    private bool isPopupVisible;

    [ObservableProperty]
    private EducationalDto selectedGame;

    public static ObservableCollection<QuestionDto> GameQuestions { get; private set; }

    [ObservableProperty]
    private ObservableCollection<EducationalDto> _filteredEducational = new();

    public static int CurrentQuestionIndex { get; set; }

    public EducationalGamesViewModel(IEducationalGameListApi educationalGameListApi)
    {
        _educationalGameListApi = educationalGameListApi;
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
            FilterEducationalGames();
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
    private void FilterEducationalGames()
    {
        var game3 = Educational.FirstOrDefault(game => game.Name == "Game 3");
        if (game3 != null)
        {
            FilteredEducational.Clear();
            FilteredEducational.Add(game3);
        }
    }

    [RelayCommand]
    private void ShowGameDetails(EducationalDto game)
    {
        if (game != null)
        {
            SelectedGame = game;

            Debug.WriteLine($"Game Selected: {SelectedGame.Name}");
            Debug.WriteLine($"Description: {SelectedGame.Description}");
            Debug.WriteLine($"ID: {SelectedGame.Id}");

            GameQuestions = new ObservableCollection<QuestionDto>(
                SelectedGame.MatchingGames.SelectMany(mg => mg.Questions).ToList());

            foreach (var question in GameQuestions)
            {
                Debug.WriteLine($" Game Questions: Question ID: {question.Id}");
            }
            CurrentQuestionIndex = 0;
            IsPopupVisible = true;
        }
        else
        {
            Debug.WriteLine("null education list");
        }
    }

    [RelayCommand]
    private async Task GoToPictureMatchingGame()
    {
        if (GameQuestions == null || GameQuestions.Count == 0)
        {
            await Shell.Current.DisplayAlert("Error", "No questions available.", "OK");
            return;
        }

        var selectedQuestion = GameQuestions[CurrentQuestionIndex];
        if (selectedQuestion != null)
        {
            var route = $"{nameof(PlayGame)}?questionId={selectedQuestion.Id}";
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
            var route = $"{nameof(PlayGame)}?questionId={nextQuestion.Id}";
            await Shell.Current.GoToAsync(route);
        }
        else
        {
            await Shell.Current.DisplayAlert("End of Game", "You have completed all questions in this game.", "OK");
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }

    [RelayCommand]
    private void ClosePopup()
    {
        IsPopupVisible = false;
    }
}