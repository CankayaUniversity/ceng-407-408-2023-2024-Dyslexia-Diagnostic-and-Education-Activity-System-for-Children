using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.Services;
using DyslexiaAppMAUI.Shared.Dtos;
using System;
using System.Diagnostics;
using System.Drawing;
using Microsoft.Maui.Graphics;
using DyslexiaApp.MAUI.Pages.Login;

namespace DyslexiaApp.MAUI.ViewModels
{
    public partial class NavigationGameViewModel : BaseViewModel
    {
        private readonly IPictureMatchingApi _pictureMatchingApi;
        private readonly DiagnosisMatchingGamesViewModel _diagnosisMatchingGamesViewModel;
        private bool _isInitialized = false;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private int _attemptCount = 1;

        private const int MaxAttempts = 10;

        [ObservableProperty]
        private bool isOptionSelected = false;

        [ObservableProperty]
        private NavigationGameDto? _question;

        [ObservableProperty]
        private string? baloonPositionText;

        [ObservableProperty]
        private Rectangle randomPosition;

        [ObservableProperty]
        private List<Rect> buttonPositions;
        public string ContinueButtonText => AttemptCount >= MaxAttempts ? "Submit" : $"{AttemptCount}/{MaxAttempts} Continue";

        public IRelayCommand ContinueCommand { get; }
        public IRelayCommand<string> CheckAnswerCommand { get; }

        private int _currentSelectionResult;

        public NavigationGameViewModel(IPictureMatchingApi pictureMatchingApi, DiagnosisMatchingGamesViewModel diagnosisMatchingGamesViewModel)
        {
            _pictureMatchingApi = pictureMatchingApi;
            _diagnosisMatchingGamesViewModel = diagnosisMatchingGamesViewModel;
            ContinueCommand = new RelayCommand(async () => await Continue());
            CheckAnswerCommand = new RelayCommand<string>(CheckAnswer);
        }

        public async Task InitializeAsync()
        {
            IsBusy = true;
            try
            {
                var question = await _pictureMatchingApi.StartGameAsync();
                Question = question;
                BaloonPositionText = question.BaloonPosition;
                SetRandomPositions();
                Debug.WriteLine($"Navigation Question: {Question}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading question details: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
                IsOptionSelected = false; // Yeni bir soru yüklendiğinde seçenek seçimi sıfırlanır
                ((RelayCommand)ContinueCommand).NotifyCanExecuteChanged();
            }
        }

        private void SetRandomPositions()
        {
            Random rnd = new Random();
            buttonPositions = new List<Rect>();
            for (int i = 0; i < 5; i++)
            {
                double x = rnd.NextDouble();
                double y = rnd.NextDouble();
                buttonPositions.Add(new Rect(x, y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            }
            OnPropertyChanged(nameof(ButtonPositions)); // Güncellemeyi bildir
        }

        private async Task Continue()
        {
            var userAnswer = new UserAnswerDto
            {
                QuestionId = Question?.Id ?? Guid.Empty,
                SelectedAnswerIndex = _currentSelectionResult
            };

            _diagnosisMatchingGamesViewModel.AnswerResults.AnswerResults.Add(userAnswer);

            if (AttemptCount < MaxAttempts)
            {
                AttemptCount++;
                OnPropertyChanged(nameof(ContinueButtonText)); // Buton metnini güncelliyoruz
                await InitializeAsync();
            }
            else
            {
                Debug.WriteLine("Maximum attempts reached.");
                Debug.WriteLine($"Answer Results Navigation: {string.Join(", ", _diagnosisMatchingGamesViewModel.AnswerResults)}");
                await Shell.Current.GoToAsync($"//{nameof(DiagnosisSymmetryInfo)}");
            }
        }

        private void CheckAnswer(string selectedAnswer)
        {
            if (selectedAnswer == BaloonPositionText)
            {
                Debug.WriteLine("Correct");
                _currentSelectionResult = 1;
            }
            else
            {
                Debug.WriteLine("Incorrect");
                _currentSelectionResult = 0;
            }

            IsOptionSelected = true; // Seçenek seçildi olarak işaretlenir
            ((RelayCommand)ContinueCommand).NotifyCanExecuteChanged();
        }
    }
}