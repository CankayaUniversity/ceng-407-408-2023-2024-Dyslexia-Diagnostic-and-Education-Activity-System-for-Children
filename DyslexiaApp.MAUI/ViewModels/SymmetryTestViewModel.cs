using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.Services;
using DyslexiaAppMAUI.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.ViewModels
{
    public partial class SymmetryTestViewModel : BaseViewModel
    {
        private readonly IPictureMatchingApi _pictureMatchingApi;
        private readonly DiagnosisSymmetryMatchViewModel _diagnosisSymmetryMatchViewModel;
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

        public SymmetryTestViewModel(IPictureMatchingApi pictureMatchingApi, DiagnosisSymmetryMatchViewModel diagnosisSymmetryMatchViewModel, DiagnosisMatchingGamesViewModel diagnosisMatchingGamesViewModel)
        {
            _pictureMatchingApi = pictureMatchingApi;
            _diagnosisSymmetryMatchViewModel = diagnosisSymmetryMatchViewModel;
            _diagnosisMatchingGamesViewModel = diagnosisMatchingGamesViewModel;
        }

        public async Task InitializeAsync(Guid questionId)
        {
            Debug.WriteLine($"Symmetry Initialize: {questionId}");
            if (_isInitialized)
                return;

            IsBusy = true;
            try
            {
                _isInitialized = true;
                Debug.WriteLine($"Symmetry In: {questionId}");
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

            if (selectedIndex == Question?.CorrectAnswerIndex)
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
            _diagnosisMatchingGamesViewModel.AnswerResults.Add(_currentSelectionResult);

            _diagnosisSymmetryMatchViewModel.GoToNextQuestionCommand.Execute(null);
        }

        private void UpdateNextButtonText()
        {
            if (_diagnosisSymmetryMatchViewModel.CurrentQuestionIndex >= _diagnosisSymmetryMatchViewModel.GameQuestions.Count - 1)
            {
                NextButtonText = "Submit";
            }
            else
            {
                NextButtonText = $"{_diagnosisSymmetryMatchViewModel.CurrentQuestionIndex + 1}/10 Continue";
            }
        }
    }
}