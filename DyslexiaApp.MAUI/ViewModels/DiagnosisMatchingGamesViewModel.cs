using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.Pages.Login;
using DyslexiaApp.MAUI.Services;
using DyslexiaAppMAUI.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace DyslexiaApp.MAUI.ViewModels
{
    public partial class DiagnosisMatchingGamesViewModel : BaseViewModel
    {
        private readonly IEducationalGameListApi _educationalGameListApi;

        [ObservableProperty]
        private EducationalDto[] _educational = [];

        private bool _isInitialized;
        [ObservableProperty]

        private EducationalDto selectedGame;

        [ObservableProperty]
        private ObservableCollection<QuestionDto> gameQuestions;

        [ObservableProperty]
        private int currentQuestionIndex;

        public async Task InitializeAsync()
        {
            if (_isInitialized)
                return;
            IsBusy = true;

            try
            {
                _isInitialized = true;
                Educational = await _educationalGameListApi.GetEducationalGamesAsync();
                SelectDefaultGame();
            }
            catch (Exception ex)
            {
                _isInitialized = false;
                await ShowErrorAlertAsync(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public DiagnosisMatchingGamesViewModel(IEducationalGameListApi educationalGameListApi)
        {
            _educationalGameListApi = educationalGameListApi;
        }

        private void SelectDefaultGame()
        {
            if (Educational != null && Educational.Length > 1)
            {
                SelectedGame = Educational[2]; // 2. oyunu seçer
                Debug.WriteLine($"Selected Game: {SelectedGame.Name}");

                SelectedGameStart();
            }
        }

        public void SelectedGameStart()
        {
            Debug.WriteLine("in");
            if (SelectedGame != null)
            {
                Debug.WriteLine($"Selected Game: {SelectedGame.Name}");
                Debug.WriteLine($"Description: {SelectedGame.Description}");
                Debug.WriteLine($"Description: {SelectedGame.Id}");

                GameQuestions = new ObservableCollection<QuestionDto>(
                    SelectedGame.MatchingGames.SelectMany(mg => mg.Questions).ToList());

                foreach (var question in GameQuestions)
                {
                    Debug.WriteLine($" Game Questions: Question ID: {question.Id}");
                }
            }
            else
            {
                Debug.WriteLine("null");
            }
        }
    }
}