using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.Pages.Login;
using DyslexiaApp.MAUI.Services;
using DyslexiaAppMAUI.Shared.Dtos;

namespace DyslexiaApp.MAUI.ViewModels;

public partial class MatchingViewModel : BaseViewModel
{
    private readonly DiagnosisMatchingGamesViewModel _diagnosisMatchingGamesViewModel;

    private bool _isInitialized = false;
    private bool _isAnswerSelected = false;
    private int _wrongAnswerCount = 0;

    public ObservableCollection<QuestionDto> GameQuestions { get; } = new ObservableCollection<QuestionDto>();

    [ObservableProperty]
    private Guid questionId;

    [ObservableProperty]
    private QuestionDto? _question;

    [ObservableProperty]
    private int? attemptsRemaining;

    public Action DecreaseAttempts { get; set; }

    [ObservableProperty]
    private int? currentAttempts = 0;

    [ObservableProperty]
    private bool? isCorrect;

    [ObservableProperty]
    private bool isAnswerCorrect;

    [ObservableProperty]
    private bool isCrossVisible;

    [ObservableProperty]
    private int score = 0;

    private int _currentQuestionIndex = 0;

    [ObservableProperty]
    private string nextButtonText;

    [ObservableProperty]
    private int totalScore;

    public MatchingViewModel(DiagnosisMatchingGamesViewModel diagnosisMatchingGamesViewModel)
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
    public async Task ItemSelectedGameAsync(ImageDto selectedImage)
    {
        if (_isAnswerSelected)
        {
            return;
        }

        var selectedIndex = Question?.ImageOptions?.IndexOf(selectedImage) ?? -1;
        Debug.WriteLine($"Seçilen öğenin indeksi: {selectedIndex}");

        if (selectedIndex == Question?.CorrectAnswerIndex)
        {
            Debug.WriteLine("Tebrikler! Doğru cevabı seçtiniz.");
            IsCorrect = true;
            IsAnswerCorrect = true;
            _isAnswerSelected = true;
            Score += 100;
            _diagnosisMatchingGamesViewModel.IncreaseTotalScore(100);
            _wrongAnswerCount = 0;
        }
        else
        {
            Debug.WriteLine("Üzgünüm, yanlış cevap.");
            IsCorrect = false;
            IsCrossVisible = true;
            IsAnswerCorrect = false;
            IsCrossVisible = true;

            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                IsCrossVisible = false;
                return false;
            });

            if (AttemptsRemaining.HasValue && AttemptsRemaining > 0)
            {
                DecreaseAttempts?.Invoke();
                AttemptsRemaining = _diagnosisMatchingGamesViewModel.AttemptsRemaining;

                _wrongAnswerCount++;
                var penalty = _wrongAnswerCount * 10;
                Score -= penalty;
                _diagnosisMatchingGamesViewModel.DecreaseTotalScore(penalty);
                //TotalScore = _diagnosisMatchingGamesViewModel.TotalScore;


                if (AttemptsRemaining <= 0)
                {
                    await Shell.Current.DisplayAlert("End of Game", "You no longer have the right to try. You are directed back to the Educational Game page.", "Return Game Page");
                    Debug.WriteLine("Deneme hakkınız kalmamıştır. Oyun sonlandırılıyor.");
                    await Shell.Current.GoToAsync($"//{nameof(EducationalGameList)}");
                }
            }
            TotalScore = _diagnosisMatchingGamesViewModel.TotalScore;
        }
    }

    [RelayCommand]
    public void GoToNextQuestion()
    {
        _diagnosisMatchingGamesViewModel.GoToNextPictureQuestionCommand.Execute(null);
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