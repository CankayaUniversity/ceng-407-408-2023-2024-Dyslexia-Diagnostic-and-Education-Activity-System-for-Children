using DyslexiaApp.MAUI.ViewModels;
using DyslexiaAppMAUI.Shared.Dtos;
using Microsoft.Maui;
using System.Diagnostics;

namespace DyslexiaApp.MAUI.Pages.Login;

[QueryProperty(nameof(QuestionId), "questionId")]
public partial class PictureMatchingGame : ContentPage
{
    private readonly MatchingViewModel _pictureViewModel;
    private EducationalGamesViewModel _educationalViewModel;

    private string _questionId;
    public string QuestionId
    {
        get => _questionId;
        set
        {
            _questionId = Uri.UnescapeDataString(value ?? string.Empty);
            LoadQuestionData(_questionId);
        }
    }
    public PictureMatchingGame(MatchingViewModel pictureViewModel, EducationalGamesViewModel educationalViewModel)
    {
        InitializeComponent();
        _pictureViewModel = pictureViewModel;
        _educationalViewModel = educationalViewModel;
        BindingContext = _pictureViewModel;

        //NextButton.Command = new Command(() => _educationalViewModel.GoToNextQuestion());
    }
    private async void LoadQuestionData(string questionId)
    {
        if (Guid.TryParse(questionId, out Guid id))
        {
            await _pictureViewModel.InitializeAsync(id);
        }
    }

    private async void Home_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}