using DyslexiaApp.MAUI.ViewModels;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using System.Text.Json;
using DyslexiaAppMAUI.Shared.Dtos;
using System.Diagnostics;

namespace DyslexiaApp.MAUI.Pages.Login
{
    [QueryProperty(nameof(QuestionJson), "questionJson")]
    public partial class LetterMatchingGame : ContentPage
    {
        private readonly LetterMatchingViewModel _letterViewModel;
        private readonly DiagnosisMatchingGamesViewModel _diagnosisMatchingGamesViewModel;

        public string QuestionJson { get; set; }

        public LetterMatchingGame(LetterMatchingViewModel letterViewModel, DiagnosisMatchingGamesViewModel diagnosisMatchingGamesViewModel)
        {
            InitializeComponent();
            _letterViewModel = letterViewModel;
            _diagnosisMatchingGamesViewModel = diagnosisMatchingGamesViewModel;
            BindingContext = _letterViewModel;

            NextButton.Command = new Command(_letterViewModel.AddCurrentSelectionResult);
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
                Debug.WriteLine($"Question ID: {question.Id}");
                if (question != null)
                {
                    _letterViewModel.InitializeAsync(question);// Set the question directly in the ViewModel
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
}