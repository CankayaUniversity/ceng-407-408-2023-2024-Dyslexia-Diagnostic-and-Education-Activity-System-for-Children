using DyslexiaApp.MAUI.ViewModels;
using DyslexiaAppMAUI.Shared.Dtos;
using Microsoft.Maui.Controls;
using DyslexiaApp.MAUI.Services;
using System.Diagnostics;
using DyslexiaAppMAUI.Shared;

namespace DyslexiaApp.MAUI.Pages.Login
{
    public partial class DiagnosisResultPage : ContentPage
    {
        private readonly DiagnosisResultViewModel _dyslexiaDiagnosisViewModel;
        private readonly DiagnosisSymmetryMatchViewModel _diagnosisSymmetryMatchViewModel;

        public DiagnosisResultPage(DyslexiaResultDto dyslexiaResultDto, DiagnosisResultViewModel diagnosisResultViewModel,DiagnosisSymmetryMatchViewModel diagnosisSymmetryMatchViewModel)
        {
            InitializeComponent();
            _dyslexiaDiagnosisViewModel = diagnosisResultViewModel;
            _diagnosisSymmetryMatchViewModel = diagnosisSymmetryMatchViewModel;
            BindingContext = _diagnosisSymmetryMatchViewModel;

            if (dyslexiaResultDto == null)
            {
                Debug.WriteLine("dyslexiaResultDto is null");
                DisplayAlert("Error", "Diagnosis result data is missing.", "OK");
                return;
            }

            Debug.WriteLine("DiagnosisResultPage constructor called with valid dyslexiaResultDto");
            LoadDiagnosisResult(dyslexiaResultDto);
        }

        private void LoadDiagnosisResult(DyslexiaResultDto dyslexiaResultDto)
        {
            try
            {
                Debug.WriteLine("LoadDiagnosisResult started");
                _dyslexiaDiagnosisViewModel.AccuracyRate = dyslexiaResultDto.AccuracyRate;
                _dyslexiaDiagnosisViewModel.DyslexiaRate = dyslexiaResultDto.DyslexiaRate;
                Debug.WriteLine("LoadDiagnosisResult completed");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
                Debug.WriteLine("Stack Trace: " + ex.StackTrace);
                DisplayAlert("Error", "An error occurred while loading the diagnosis result. Please try again.", "OK");
            }
        }

        private async void GoToProfile(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(ProfilePage)}");
        }

        private async void Close_Button(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}
