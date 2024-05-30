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

        [ObservableProperty]

        private int selectedIndex;

        public SymmetryTestViewModel(DiagnosisMatchingGamesViewModel diagnosisMatchingGamesViewModel)
        {
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
                Debug.WriteLine($"Question Initialized: {Question.Id}");
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
                if (Question == null)
                {
                    Debug.WriteLine("Question is null.");
                    return new ObservableCollection<ImageDto>();
                }

                if (Question.ImageOptions == null)
                {
                    Debug.WriteLine("ImageOptions is null.");
                    return new ObservableCollection<ImageDto>();
                }

                if (Question.MainImage == null)
                {
                    Debug.WriteLine("MainImage is null.");
                    return new ObservableCollection<ImageDto>();
                }

                Debug.WriteLine("Original ImageOptions:");
                for (int i = 0; i < Question.ImageOptions.Count; i++)
                {
                    Debug.WriteLine($"Index {i}: {Question.ImageOptions[i].Id}");
                }

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
            SelectedIndex = Question?.ImageOptions?.IndexOf(selectedImage) ?? -1;
            Debug.WriteLine($"Selected item index: {SelectedIndex}");

            IsOptionSelected = true;

            

            if (SelectedIndex == Question?.CorrectAnswerIndex)
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
            _diagnosisMatchingGamesViewModel.GoToNextSymmetryQuestionCommand.Execute(null);
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