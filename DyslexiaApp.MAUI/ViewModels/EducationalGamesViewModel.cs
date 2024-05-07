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

    [ObservableProperty]
    private bool isPopupVisible;

    [ObservableProperty]
    private EducationalDto selectedGame;

    public EducationalGamesViewModel(IEducationalGameListApi educationalGameListApi)
    {
        _educationalGameListApi = educationalGameListApi;
    }

    //[ObservableProperty]
    //private ObservableCollection<QuestionDto> gameQuestions;

    [RelayCommand]
    private void ShowGameDetails(EducationalDto game)
    {
        if (game != null)
        {
            SelectedGame = game;
            IsPopupVisible = true;

            Debug.WriteLine($"Game Selected: {SelectedGame.Name}");
            Debug.WriteLine($"Description: {SelectedGame.Description}");
            Debug.WriteLine($"ID: {SelectedGame.Id}");

            //GameQuestions = new ObservableCollection<QuestionDto>(
            //   SelectedGame.MatchingGames.SelectMany(mg => mg.Questions));

            foreach (var matchingGame in SelectedGame.MatchingGames)
            {
                Debug.WriteLine($"Matching Game ID: {matchingGame.Id}");
                foreach (var question in matchingGame.Questions)
                {
                    Debug.WriteLine($"Question ID: {question.Id}");
                }
            }


        }
    }

    // In EducationalGamesViewModel.cs
    [RelayCommand]
    private async Task GoToPictureMatchingGame(QuestionDto selectedQuestion)
    {
        if (selectedQuestion != null)
        {
            var route = $"{nameof(PictureMatchingGame)}?questionId={selectedQuestion.Id}";
            await Shell.Current.GoToAsync(route);
            Debug.WriteLine($"Navigating to PictureMatchingGame with Question ID: {selectedQuestion.Id}");
        }
    }



    [RelayCommand]
    private void ClosePopup()
    {
        IsPopupVisible = false;
    }

}