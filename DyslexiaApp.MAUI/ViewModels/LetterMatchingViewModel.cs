using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.Pages.Login;
using DyslexiaApp.MAUI.Services;
using DyslexiaAppMAUI.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.ViewModels;

public partial class LetterMatchingViewModel : BaseViewModel
{
    private readonly IPictureMatchingApi _pictureMatchingApi;
    private bool _isInitialized = false;

    public ObservableCollection<QuestionDto> GameQuestions { get; } = new ObservableCollection<QuestionDto>();

    [ObservableProperty]
    private Guid questionId;

    [ObservableProperty]
    private QuestionDto? _question;

    [ObservableProperty]
    private int? attemptsRemaining = 3;

    [ObservableProperty]
    private int? currentAttempts = 0;

    [ObservableProperty]
    private bool? isCorrect;

    [ObservableProperty]
    private bool isAnswerCorrect;

    [ObservableProperty]
    private bool isCrossVisible;

    private int _currentQuestionIndex = 0;
    public int CurrentQuestionIndex
    {
        get => _currentQuestionIndex;
        private set => SetProperty(ref _currentQuestionIndex, value);
    }
    public int TotalQuestions => GameQuestions.Count;
    public LetterMatchingViewModel(IPictureMatchingApi pictureMatchingApi)
    {
        _pictureMatchingApi = pictureMatchingApi;
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
            Question = question;
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

            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                IsCrossVisible = false; // 3 saniye sonra cross.png'yi gizle
                return false; // Timer'ı durdur
            });

            if (CurrentAttempts.HasValue && AttemptsRemaining.HasValue && AttemptsRemaining > 0)
            {
                CurrentAttempts++;
                AttemptsRemaining--;

                if (AttemptsRemaining <= 0)
                {
                    Debug.WriteLine("Deneme hakkınız kalmamıştır. Oyun sonlandırılıyor.");
                    Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                }
            }
        }
    }
}