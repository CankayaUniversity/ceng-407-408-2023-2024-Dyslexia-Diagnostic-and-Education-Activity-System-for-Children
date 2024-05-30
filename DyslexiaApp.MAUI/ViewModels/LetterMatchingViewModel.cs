using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.Services;
using DyslexiaAppMAUI.Shared.Dtos;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.ViewModels
{
    public partial class LetterMatchingViewModel : BaseViewModel
    {
        private readonly IPictureMatchingApi _pictureMatchingApi;
        private readonly DiagnosisMatchingGamesViewModel _diagnosisMatchingGamesViewModel;
        private bool _isInitialized = false;

        public ObservableCollection<QuestionDto> GameQuestions { get; } = new ObservableCollection<QuestionDto>();

        [ObservableProperty]
        private Guid questionId;

        [ObservableProperty]
        private QuestionDto? _question;

        [ObservableProperty]
        private bool? isCorrect;

        [ObservableProperty]
        private bool isAnswerCorrect;

        [ObservableProperty]
        private bool isCrossVisible;

        [ObservableProperty]
        private bool isOptionSelected;

        [ObservableProperty]
        private string nextButtonText;

        private int _currentSelectionResult;

        public LetterMatchingViewModel(IPictureMatchingApi pictureMatchingApi, DiagnosisMatchingGamesViewModel diagnosisMatchingGamesViewModel)
        {
            _pictureMatchingApi = pictureMatchingApi;
            _diagnosisMatchingGamesViewModel = diagnosisMatchingGamesViewModel;
        }

        public async Task InitializeAsync(Guid questionId)
        {
            if (_isInitialized)
                return;

            IsBusy = true;
            try
            {
                _isInitialized = true;
                Debug.WriteLine($"Letter Matching In: {questionId}");
                var question = await _pictureMatchingApi.GetQuestionByIdAsync(questionId);
                Console.WriteLine(question);
                Question = question;
                UpdateNextButtonText();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading question details: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ObservableCollection<ImageDto> FilteredImageOptions
        {
            get
            {
                return new ObservableCollection<ImageDto>(Question?.ImageOptions.Skip(1) ?? new List<ImageDto>());
            }
        }

        partial void OnQuestionChanged(QuestionDto value)
        {
            OnPropertyChanged(nameof(FilteredImageOptions));
        }

        [RelayCommand]
        public void ItemSelectedGame(ImageDto selectedImage)
        {
            var selectedIndex = Question?.ImageOptions?.IndexOf(selectedImage) ?? -1;
            Debug.WriteLine($"Selected item index: {selectedIndex}");

            IsOptionSelected = true;

            var userAnswer = new UserAnswerDto
            {
                QuestionId = Question?.Id ?? Guid.Empty,
                SelectedAnswerIndex = selectedIndex
            };

            if (selectedIndex == Question?.CorrectAnswerIndex)
            {
                Debug.WriteLine("Tebrikler! Doğru cevabı seçtiniz.");
                IsCorrect = true;
                _currentSelectionResult = 1; // Geçici olarak sonucu sakla
            }
            else
            {
                Debug.WriteLine("Maalesef, yanlış cevap.");
                IsCorrect = false;
                _currentSelectionResult = 0; // Geçici olarak sonucu sakla
            }

            // Kullanıcı cevabını listeye ekle
            _diagnosisMatchingGamesViewModel.AnswerResults.AnswerResults.Add(userAnswer);
        }

        [RelayCommand]
        public void AddCurrentSelectionResult()
        {
            _diagnosisMatchingGamesViewModel.GoToNextQuestionCommand.Execute(null);
        }

        private void UpdateNextButtonText()
        {
            if (_diagnosisMatchingGamesViewModel.CurrentQuestionIndex >= _diagnosisMatchingGamesViewModel.GameQuestions.Count - 1)
            {
                NextButtonText = "Submit";
            }
            else
            {
                NextButtonText = $"{_diagnosisMatchingGamesViewModel.CurrentQuestionIndex + 1}/10 Continue";
            }
        }
    }
}