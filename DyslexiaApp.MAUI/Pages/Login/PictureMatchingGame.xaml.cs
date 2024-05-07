using DyslexiaApp.MAUI.ViewModels;
using DyslexiaAppMAUI.Shared.Dtos;
using System.Diagnostics;

namespace DyslexiaApp.MAUI.Pages.Login;

[QueryProperty(nameof(QuestionId), "questionId")]
public partial class PictureMatchingGame : ContentPage
{
    private readonly PictureMatchingViewModel _pictureViewModel;

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

    public PictureMatchingGame(PictureMatchingViewModel pictureViewModel)
    {
        InitializeComponent();
        _pictureViewModel = pictureViewModel;
        BindingContext = _pictureViewModel;

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