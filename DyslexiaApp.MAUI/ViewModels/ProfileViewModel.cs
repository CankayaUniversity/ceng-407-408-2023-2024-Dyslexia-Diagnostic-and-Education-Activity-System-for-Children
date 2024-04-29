using CommunityToolkit.Mvvm.ComponentModel;
using DyslexiaApp.MAUI.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.ViewModels;

public partial class ProfileViewModel(AuthService authService) : BaseViewModel
{
    private readonly AuthService _authService = authService;

    [ObservableProperty]
    private string? _firstName;

    [ObservableProperty]
    private string? _lastName;

    [ObservableProperty]
    private string? _email;

    [ObservableProperty]
    private DateTime _birthdate;

    [ObservableProperty]
    private string? _gender;

    private bool _isInitialized;


    public async Task InitializeAsync()
    {
        if (_isInitialized)
            return;

        IsBusy = true;
        try
        {
            _isInitialized = true;
            if (_authService.User != null)
            {
                FirstName = _authService.User.Name;
                LastName = _authService.User.LastName;
                Email = _authService.User.Email;
                Birthdate = _authService.User.Birthday;
                Gender = _authService.User.Gender;

                Debug.WriteLine($"Name: {FirstName}");
                Debug.WriteLine($"LastName: {LastName}");
                Debug.WriteLine($"Email: {Email}");
                Debug.WriteLine($"Birthday: {Birthdate}");
                Debug.WriteLine($"Gender: {Gender}");
            }
            else
            {
                Debug.WriteLine("AuthService.User is null");
            }
        }
        catch (Exception ex)
        {
            await ShowErrorAlertAsync(ex.Message);
            Debug.WriteLine($"Error loading user details: {ex.Message}");
        }
        finally
        {
            IsBusy = false;
        }
    }

}