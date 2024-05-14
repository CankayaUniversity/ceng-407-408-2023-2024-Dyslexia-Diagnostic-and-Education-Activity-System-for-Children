using DyslexiaApp.MAUI.ViewModels;
using Microsoft.Maui;
using System.Diagnostics;

namespace DyslexiaApp.MAUI.Pages.Login;

[QueryProperty(nameof(QuestionId), "questionId")]
public partial class LetterMatchingGame : ContentPage
{
    private readonly LetterMatchingViewModel _letterViewModel;
    private DiagnosisMatchingGamesViewModel _diagnosisViewModel;

    private string _questionId;
    public string QuestionId
    {
        get => _questionId;
        set
        {
            _questionId = Uri.UnescapeDataString(value ?? string.Empty);
            Debug.WriteLine($"Game Selected: {_questionId}");
            LoadQuestionData(_questionId);
        }
    }

    public LetterMatchingGame(LetterMatchingViewModel letterViewModel, DiagnosisMatchingGamesViewModel diagnosisViewModel)
    {
        InitializeComponent();
        _letterViewModel = letterViewModel;
        _diagnosisViewModel = diagnosisViewModel;
        BindingContext = _letterViewModel;
    }
    private async void LoadQuestionData(string questionId)
    {
        if (Guid.TryParse(questionId, out Guid id))
        {
            await _letterViewModel.InitializeAsync(id);
        }
    }

    private async void Home_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}