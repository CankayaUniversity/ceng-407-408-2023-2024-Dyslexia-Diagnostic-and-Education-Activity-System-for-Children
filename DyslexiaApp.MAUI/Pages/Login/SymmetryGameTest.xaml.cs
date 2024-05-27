using DyslexiaApp.MAUI.ViewModels;
using System.Diagnostics;

namespace DyslexiaApp.MAUI.Pages.Login;

[QueryProperty(nameof(QuestionId), "questionId")]
public partial class SymmetryGameTest : ContentPage
{
    private string _questionId;
    private readonly SymmetryTestViewModel _symmetryTestViewModel;
    private readonly DiagnosisSymmetryMatchViewModel _diagnosisSymmetryMatchViewModel;

    public string QuestionId
    {
        get => _questionId;
        set
        {
            _questionId = Uri.UnescapeDataString(value ?? string.Empty);
            Debug.WriteLine($"Selected Question Id : {_questionId}");
            LoadQuestionData(_questionId);
        }
    }

    public SymmetryGameTest(SymmetryTestViewModel symmetryTestViewModel, DiagnosisSymmetryMatchViewModel diagnosisSymmetryMatchViewModel)
    {
        InitializeComponent();
        _symmetryTestViewModel = symmetryTestViewModel;
        _diagnosisSymmetryMatchViewModel = diagnosisSymmetryMatchViewModel;
        BindingContext = _symmetryTestViewModel;

        NextButton.Command = new Command(_symmetryTestViewModel.AddCurrentSelectionResult);
    }

    private async void LoadQuestionData(string questionId)
    {
        Debug.WriteLine($"Load Question Id : {questionId}");
        if (Guid.TryParse(questionId, out Guid id))
        {
            await _symmetryTestViewModel.InitializeAsync(id);
        }
    }

    private async void Home_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}