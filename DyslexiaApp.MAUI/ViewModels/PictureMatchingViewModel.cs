using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.Services;
using DyslexiaAppMAUI.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DyslexiaApp.MAUI.ViewModels;

[QueryProperty(nameof(QuestionId), nameof(QuestionId))]

public partial class PictureMatchingViewModel : BaseViewModel
{
    private readonly IPictureMatchingApi _pictureMatchingApi;

    [ObservableProperty]
    private QuestionDto? _question;

    private bool _isInitialized;

    [ObservableProperty]
    private Guid questionId;

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
            var question = await _pictureMatchingApi.GetQuestionByIdAsync(questionId); // Buraya bir breakpoint ekleyin
            Question = question; // Bu satıra da bir breakpoint ekleyin

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading question details: {ex.Message}");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]

    public void CheckAnswer(int selectedIndex)
    {
        IsBusy = true;
        currentAttempts++;

        if (selectedIndex == Question.CorrectAnswerIndex)
        {
            isCorrect = true;
            //LoadNextQuestion();
        }
        else
        {
            isCorrect = false;
            AttemptsRemaining--;
            if (AttemptsRemaining == 0)
            {
                EndGame();
            }
        }

        IsBusy = false;
    }
    private void EndGame()
    {
        // Oyun sonu mantığı, örneğin sonuçları gösterme veya ana menüye dönme
        Console.WriteLine("Oyun bitti, kalan hakkınız: " + attemptsRemaining);
    }

}