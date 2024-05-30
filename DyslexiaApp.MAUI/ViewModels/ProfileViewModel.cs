using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.Services;
using DyslexiaAppMAUI.Shared.Dtos;
using Refit;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        private readonly AuthService _authService;

        [ObservableProperty]
        private string? _name = string.Empty;

        [ObservableProperty]
        private string? _lastName;

        [ObservableProperty]
        private string? _email;

        [ObservableProperty]
        private DateTime _birthdate;

        [ObservableProperty]
        private string? _gender;

        [ObservableProperty]
        private string? _statusMessage;

        [ObservableProperty]
        private Color _statusMessageColor;

        [ObservableProperty]
        private int _accuracy;


        private bool _isInitialized;

        public ProfileViewModel(AuthService authService)
        {
            _authService = authService;
        }

        public async Task InitializeAsync()
        {
            if (_authService.User != null)
            {
                Name = _authService.User.Name;
                LastName = _authService.User.LastName;
                Email = _authService.User.Email;
                Birthdate = _authService.User.Birthday;
                Gender = _authService.User.Gender;
                Accuracy = _authService.User.Accuracy;


                Debug.WriteLine($"Name: {Name}");
                Debug.WriteLine($"LastName: {LastName}");
                Debug.WriteLine($"Email: {Email}");
                Debug.WriteLine($"Birthday: {Birthdate}");
                Debug.WriteLine($"Gender: {Gender}");
                Debug.WriteLine($"Accuracy: {Accuracy}");
                
            }
            else
            {
                Debug.WriteLine("AuthService.User is null");
            }

            if (_isInitialized)
                return;

            IsBusy = true;
            try
            {
                _isInitialized = true;
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

        [RelayCommand]
        public async Task UpdateUserProfile()
        {
            if (_authService.User == null)
            {
                await ShowErrorAlertAsync("User not authenticated.");
                return;
            }

            var userId = _authService.User.Id;
            var dto = new UpdateUserDto(
                FirstName: Name!,
                LastName: LastName!,
                Email: Email!,
                Birthday: Birthdate,
                Gender: Gender!
            );

            IsBusy = true;
            try
            {
                var result = await _authService.UpdateUserAsync(userId, dto);
                if (result.IsSuccess)
                {
                    StatusMessage = "Profile updated successfully.";
                    StatusMessageColor = Colors.Green;
                    await ShowSuccessAlertAsync("User profile updated successfully.");
                }
                else
                {
                    StatusMessage = "Something went wrong.";
                    StatusMessageColor = Colors.Red;
                    await ShowErrorAlertAsync(result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                await ShowErrorAlertAsync(ex.Message);
                Debug.WriteLine($"Error updating user profile: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private Task ShowErrorAlertAsync(string message)
        {
            // Implement your error alert logic here
            Debug.WriteLine(message);
            return Task.CompletedTask;
        }

        private Task ShowSuccessAlertAsync(string message)
        {
            // Implement your success alert logic here
            Debug.WriteLine(message);
            return Task.CompletedTask;
        }
    }
}