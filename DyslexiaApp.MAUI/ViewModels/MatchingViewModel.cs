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
    private readonly IPictureMatchingApi _pictureMatchingApi;
    private readonly EducationalGamesViewModel _educationalGamesViewModel;
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

    public MatchingViewModel(IPictureMatchingApi pictureMatchingApi, EducationalGamesViewModel educationalGamesViewModel)
    {
        _pictureMatchingApi = pictureMatchingApi;
        _educationalGamesViewModel = educationalGamesViewModel;
    }

    public async Task InitializeAsync(Guid questionId)
    {
        if (_isInitialized)
            return;

        IsBusy = true;
        try
        {
            _isInitialized = true;
            Debug.WriteLine($"Loading question details: {questionId}");
            var question = await _pictureMatchingApi.GetQuestionByIdAsync(questionId);
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
            _educationalGamesViewModel.IncreaseTotalScore(100);
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
                AttemptsRemaining = _educationalGamesViewModel.AttemptsRemaining;

                _wrongAnswerCount++;
                var penalty = _wrongAnswerCount * 10;
                Score -= penalty;
                _educationalGamesViewModel.DecreaseTotalScore(penalty);

                if (AttemptsRemaining <= 0)
                {
                    await Shell.Current.DisplayAlert("End of Game", "You no longer have the right to try. You are directed back to the Educational Game page.", "Return Game Page");
                    Debug.WriteLine("Deneme hakkınız kalmamıştır. Oyun sonlandırılıyor.");
                    await Shell.Current.GoToAsync($"//{nameof(EducationalGameList)}");
                }
            }
        }
    }

    private void UpdateNextButtonText()
    {
        if (_educationalGamesViewModel.CurrentQuestionIndex >= _educationalGamesViewModel.GameQuestions.Count - 1)
        {
            NextButtonText = "Submit";
        }
        else
        {
            NextButtonText = $"{_educationalGamesViewModel.CurrentQuestionIndex + 1}/10 Continue";
        }
    }
}