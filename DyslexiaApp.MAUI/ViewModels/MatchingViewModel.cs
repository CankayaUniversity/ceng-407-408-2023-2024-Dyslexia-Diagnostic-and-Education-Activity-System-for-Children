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
    public void ItemSelectedGame(ImageDto selectedImage)
    {
        var selectedIndex = Question?.ImageOptions?.IndexOf(selectedImage) ?? -1;
        Debug.WriteLine($"Seçilen öğenin indeksi: {selectedIndex}");

        if (selectedIndex == Question?.CorrectAnswerIndex)
        {
            Debug.WriteLine("Tebrikler! Doğru cevabı seçtiniz.");
            IsCorrect = true;
            IsAnswerCorrect = true;

        }
        else
        {
            Debug.WriteLine("Üzgünüm, yanlış cevap.");
            IsCorrect = false;
            IsCrossVisible = true;

            IsAnswerCorrect = false;
            IsCrossVisible = true;

            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                IsCrossVisible = false; // 3 saniye sonra cross.png'yi gizle
                return false; // Timer'ı durdur
            });

            if (AttemptsRemaining.HasValue && AttemptsRemaining > 0)
            {
                DecreaseAttempts?.Invoke();
                AttemptsRemaining = _educationalGamesViewModel.AttemptsRemaining;

                if (AttemptsRemaining <= 0)
                {
                    Debug.WriteLine("Deneme hakkınız kalmamıştır. Oyun sonlandırılıyor.");
                    Shell.Current.GoToAsync($"//{nameof(HomePage)}");
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