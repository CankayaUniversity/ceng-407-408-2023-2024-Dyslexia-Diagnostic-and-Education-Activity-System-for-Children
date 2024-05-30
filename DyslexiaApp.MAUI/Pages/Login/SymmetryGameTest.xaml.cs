using DyslexiaApp.MAUI.ViewModels;
using DyslexiaAppMAUI.Shared.Dtos;
using System.Diagnostics;
using System.Text.Json;

namespace DyslexiaApp.MAUI.Pages.Login;


[QueryProperty(nameof(QuestionJson), "questionJson")]
public partial class SymmetryGameTest : ContentPage
{
    //private string _questionId;
    private readonly SymmetryTestViewModel _symmetryTestViewModel;
    private readonly DiagnosisMatchingGamesViewModel _diagnosisMatchingGamesViewModel;

    public string QuestionJson { get; set; }

    public SymmetryGameTest(SymmetryTestViewModel symmetryTestViewModel, DiagnosisMatchingGamesViewModel diagnosisMatchingGamesViewModel)
    {
        InitializeComponent();
        _symmetryTestViewModel = symmetryTestViewModel;
        _diagnosisMatchingGamesViewModel = diagnosisMatchingGamesViewModel;
        BindingContext = _symmetryTestViewModel;

        NextButton.Command = new Command(_symmetryTestViewModel.AddCurrentSelectionResult);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (!string.IsNullOrEmpty(QuestionJson))
        {
            await LoadQuestionData(QuestionJson);
        }
    }

    private async Task LoadQuestionData(string questionJson)
    {
        try
        {
            var question = JsonSerializer.Deserialize<QuestionDto>(questionJson);
            if (question != null)
            {
                await _symmetryTestViewModel.InitializeAsync(question); // Initialize the ViewModel with the question
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deserializing question: {ex.Message}");
            await DisplayAlert("Error", "Failed to load question.", "OK");
        }
    }

    private async void Home_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}