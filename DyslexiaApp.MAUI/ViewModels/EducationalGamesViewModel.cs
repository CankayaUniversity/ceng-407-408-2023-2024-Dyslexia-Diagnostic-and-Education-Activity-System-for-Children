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

namespace DyslexiaApp.MAUI.ViewModels
{
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

        public ObservableCollection<QuestionDto> GameQuestions { get; private set; }

        [ObservableProperty]
        private ObservableCollection<EducationalDto> _filteredEducational = new();

        public int CurrentQuestionIndex { get; set; }

        private const int TotalAttempts = 3;
        public int AttemptsRemaining { get; private set; }

        [ObservableProperty]
        private int totalScore = 0;

        public EducationalGamesViewModel(IEducationalGameListApi educationalGameListApi)
        {
            _educationalGameListApi = educationalGameListApi;
            AttemptsRemaining = TotalAttempts;
            IsPopupVisible = false;
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

        public void ResetPopupVisibility()
        {
            IsPopupVisible = false;
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

                AttemptsRemaining = TotalAttempts;

                CurrentQuestionIndex = 0;
                IsPopupVisible = true;
            }
            else
            {
                Debug.WriteLine("null education list");
            }
        }

        [RelayCommand]
        public async Task GoToPictureMatchingGame()
        {
            TotalScore = 0;
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
                Debug.WriteLine($"Total Score: {TotalScore}");
                CurrentQuestionIndex++;
                var nextQuestion = GameQuestions[CurrentQuestionIndex];
                Debug.WriteLine($"Next Question ID: {nextQuestion.Id}");
                var route = $"{nameof(PlayGame)}?questionId={nextQuestion.Id}";
                await Shell.Current.GoToAsync(route);
            }
            else
            {

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
    }
}