using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.Pages.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.ViewModels;

public partial class DiagnosisNavigationViewModel : BaseViewModel
{

    private bool _isInitialized;

    public async Task InitializeAsync()
    {
        if (_isInitialized)
            return;
        IsBusy = true;

        try
        {
            _isInitialized = true;
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

    [RelayCommand]
    public async Task GoToNavigationGame()
    {
        await Shell.Current.GoToAsync($"//{nameof(NavigationSkillsGame)}");
    }
}