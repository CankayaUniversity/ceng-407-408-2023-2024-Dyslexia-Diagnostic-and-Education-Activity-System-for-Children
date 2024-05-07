using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.Pages.Login;
using DyslexiaApp.MAUI.Services;
using DyslexiaAppMAUI.Shared.Dtos;

namespace DyslexiaApp.MAUI.ViewModels;

public partial class PictureMatchingViewModel : BaseViewModel
{
    private readonly IPictureMatchingApi _pictureMatchingApi;
    private bool _isInitialized = false;

    [ObservableProperty]
    private Guid questionId;

    //[ObservableProperty]
    //private ObservableCollection<QuestionDto> questions;

    [ObservableProperty]
    private QuestionDto? _question;

    // Kullanıcının kalan hakkı
    [ObservableProperty]
    private int? attemptsRemaining = 3;

    // Mevcut soru için yapılan deneme sayısı
    [ObservableProperty]
    private int? currentAttempts = 0;

    // Cevabın doğruluğunu takip eder
    [ObservableProperty]
    private bool? isCorrect;

    public PictureMatchingViewModel(IPictureMatchingApi pictureMatchingApi)
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

    [ObservableProperty]
    private bool isAnswerCorrect;

    [ObservableProperty]
    private bool isCrossVisible;

    [RelayCommand]
    public void ItemSelectedGame(ImageDto selectedImage)
    {
        var selectedIndex = Question?.ImageOptions?.IndexOf(selectedImage) ?? -1;
        Debug.WriteLine($"Seçilen öğenin indeksi: {selectedIndex}");

        // Doğru cevap kontrolü
        if (selectedIndex == Question?.CorrectAnswerIndex)
        {
            Debug.WriteLine("Tebrikler! Doğru cevabı seçtiniz.");
            IsCorrect = true;
            // Burada kullanıcıya başarılı olduğunu bildiren bir mesaj gösterebilirsiniz.
            // Ayrıca, sonraki soruya geçiş yapabilirsiniz veya oyunu sonlandırabilirsiniz.
            IsAnswerCorrect = true;

        }
        else
        {
            Debug.WriteLine("Üzgünüm, yanlış cevap.");
            IsCorrect = false;
            IsCrossVisible = true; // cross.png'yi göster

            // Burada kullanıcıya yanlış cevap verdiğini bildiren bir mesaj gösterebilirsiniz.
            // Ayrıca, kullanıcının tekrar deneme hakkı varsa, deneme sayısını azaltabilirsiniz.

            IsAnswerCorrect = false;
            IsCrossVisible = true; // cross.png'yi göster

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
                    // Oyunu sonlandırma ve kullanıcıyı başka bir sayfaya yönlendirme
                    Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                }
            }
        }

    }
}