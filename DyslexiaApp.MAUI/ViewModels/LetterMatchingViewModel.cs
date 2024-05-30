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

        private QuestionDto _currentQuestion;
        public QuestionDto CurrentQuestion
        {
            get => _currentQuestion;
            set => SetProperty(ref _currentQuestion, value);
        }
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

        [ObservableProperty]
        private int selectedIndex;


        public LetterMatchingViewModel(IPictureMatchingApi pictureMatchingApi, DiagnosisMatchingGamesViewModel diagnosisMatchingGamesViewModel)
        {
            _pictureMatchingApi = pictureMatchingApi;
            _diagnosisMatchingGamesViewModel = diagnosisMatchingGamesViewModel;
        }

        public async Task InitializeAsync(QuestionDto question)
        {
            if (_isInitialized)
                return;

            IsBusy = true;
            try
            {
                _isInitialized = true;
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
                if (Question?.ImageOptions == null || Question.MainImage == null)
                {
                    Debug.WriteLine("ImageOptions or MainImage is null.");
                    return new ObservableCollection<ImageDto>();
                }

                Debug.WriteLine("Original ImageOptions:");
                for (int i = 0; i < Question.ImageOptions.Count; i++)
                {
                    Debug.WriteLine($"Index {i}: {Question.ImageOptions[i].Id}");
                }

                // Filter out the main image
                var filteredOptions = Question.ImageOptions.Where(img => img.Id != Question.MainImage.Id).ToList();

                Debug.WriteLine("Filtered ImageOptions:");
                for (int i = 0; i < filteredOptions.Count; i++)
                {
                    Debug.WriteLine($"Index {i}: {filteredOptions[i].Id}");
                }

                return new ObservableCollection<ImageDto>(filteredOptions);
            }
        }



        partial void OnQuestionChanged(QuestionDto value)
        {
            OnPropertyChanged(nameof(FilteredImageOptions));
        }

        [RelayCommand]
        public void ItemSelectedGame(ImageDto selectedImage)
        {
            Debug.WriteLine($"q:{Question.Id}");
            SelectedIndex = Question?.ImageOptions?.IndexOf(selectedImage) ?? -1;
            Debug.WriteLine($"Selected item index: {selectedIndex}");

            IsOptionSelected = true;

            if (SelectedIndex == Question?.CorrectAnswerIndex)
            {
                Debug.WriteLine("Congratulations! You selected the correct answer.");
                IsCorrect = true;
                _currentSelectionResult = 1; // Store the result temporarily
            }
            else
            {
                Debug.WriteLine("Sorry, incorrect answer.");
                IsCorrect = false;
                _currentSelectionResult = 0; // Store the result temporarily
            }
        }

        [RelayCommand]
        public void AddCurrentSelectionResult()
        {
            var userAnswer = new UserAnswerDto
            {
                QuestionId = Question?.Id ?? Guid.Empty,
                SelectedAnswerIndex = SelectedIndex
            };

            _diagnosisMatchingGamesViewModel.AnswerResults.AnswerResults.Add(userAnswer);

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

