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

namespace DyslexiaApp.MAUI.ViewModels
{
    public partial class EducationalGamesViewModel(IEducationalGameListApi educationalGameListApi) : BaseViewModel
    {
        private readonly IEducationalGameListApi _educationalGameListApi = educationalGameListApi;

        [ObservableProperty]
        private EducationalDto[] _educational = [];


        private bool _isInitialized;

        public async Task InitializeAsync()
        {
            if (_isInitialized)
                return;
            IsBusy = true;

            try
            {
                _isInitialized = true;
                Educational = await _educationalGameListApi.GetEducationalGamesAsync();

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

        [ObservableProperty]
        private bool isPopupVisible;

        [ObservableProperty]
        private EducationalDto selectedGame;

        // ShowGameDetailsCommand, seçilen oyunun ayrıntılarını göstermek için kullanılır.
        [RelayCommand]
        private void ShowGameDetails(EducationalDto game)
        {
            if (game != null)
            {
                SelectedGame = game;
                IsPopupVisible = true;
            }
        }

        [RelayCommand]
        private void ClosePopup()
        {
            IsPopupVisible = false;
        }

        [RelayCommand]
        private async Task GoToPictureMatchingGame()
        {
            await Shell.Current.GoToAsync($"//{nameof(PictureMatchingGame)}");
        }
    }
}