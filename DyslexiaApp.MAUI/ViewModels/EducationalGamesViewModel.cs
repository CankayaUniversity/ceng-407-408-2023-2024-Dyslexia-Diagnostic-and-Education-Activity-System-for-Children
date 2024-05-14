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

    [ObservableProperty]
    private ObservableCollection<QuestionDto> gameQuestions;

    [ObservableProperty]
    private int currentQuestionIndex;

    public async Task InitializeAsync()
    {
        if (_isInitialized)
            return;
        IsBusy = true;

        try
        {
            _isInitialized = true;
            Educational = await _educationalGameListApi.GetEducationalGamesAsync();

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

    public EducationalGamesViewModel(IEducationalGameListApi educationalGameListApi)
    {
        _educationalGameListApi = educationalGameListApi;
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
    }

    [RelayCommand]
    private async Task GoToPictureMatchingGame()
    {
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
        if (CurrentQuestionIndex < GameQuestions.Count - 1)
        {
            CurrentQuestionIndex++;
            var nextQuestion = GameQuestions[CurrentQuestionIndex];
            Debug.WriteLine($"next Question ID: {nextQuestion.Id}");
            var route = $"{nameof(PictureMatchingGame)}?questionId={nextQuestion.Id}";
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

//[RelayCommand]
//private async Task GoToPictureMatchingGame()
//{
//    var selectedQuestion = gameQuestions[currentQuestionIndex];
//    if (selectedQuestion != null)
//    {
//        var route = $"{nameof(PictureMatchingGame)}?questionId={selectedQuestion.Id}";
//        await Shell.Current.GoToAsync(route);
//        Debug.WriteLine($"Navigating to PictureMatchingGame with Question ID: {selectedQuestion.Id}");
//    }
//}
//[RelayCommand]
//public async Task GoToNextQuestion()
//{
//    if (CurrentQuestionIndex < GameQuestions.Count - 1)
//    {
//        CurrentQuestionIndex++;
//        var nextQuestion = GameQuestions[CurrentQuestionIndex];
//        Debug.WriteLine($"next Question ID: {nextQuestion.Id}");
//        var route = $"{nameof(PictureMatchingGame)}?questionId={nextQuestion.Id}";
//        await Shell.Current.GoToAsync(route);
//    }
//    else
//    {
//        await Shell.Current.DisplayAlert("End of Game", "You have completed all questions in this game.", "OK");
//    }
//}