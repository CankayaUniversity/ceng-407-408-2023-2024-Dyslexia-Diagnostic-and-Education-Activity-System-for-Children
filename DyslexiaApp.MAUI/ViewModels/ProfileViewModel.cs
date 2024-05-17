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

                Debug.WriteLine($"Name: {Name}");
                Debug.WriteLine($"LastName: {LastName}");
                Debug.WriteLine($"Email: {Email}");
                Debug.WriteLine($"Birthday: {Birthdate}");
                Debug.WriteLine($"Gender: {Gender}");
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
        public async Task UpdateProfileAsync()
        {
            try
            {
                // Generate profile update token
                var generateTokenResult = await _authService.GenerateProfileUpdateTokenAsync(Email!);
                Debug.WriteLine($"generateTokenResult: {generateTokenResult}");
                Debug.WriteLine($"generateTokenResult IsSuccess: {generateTokenResult.IsSuccess}");
                Debug.WriteLine($"generateTokenResult Data: {generateTokenResult.Data}");
                Debug.WriteLine($"generateTokenResult ErrorMessage: {generateTokenResult.ErrorMessage}");

                if (!generateTokenResult.IsSuccess)
                {
                    Debug.WriteLine($"Failed to generate token: {generateTokenResult.ErrorMessage}");
                    return;
                }

                var updateWithTokenDto = new UpdateUserWithTokenDto
                {
                    Id = _authService.User!.Id,
                    FirstName = Name,
                    LastName = LastName,
                    Email = Email,
                    Birthday = Birthdate,
                    Gender = Gender,
                    Token = generateTokenResult.Data!.Token // Token'ı buraya ekleyin
                };

                var result = await _authService.UpdateUserProfileWithTokenAsync(updateWithTokenDto);
                Debug.WriteLine($"result: {result}");
                Debug.WriteLine($"result IsSuccess: {result.IsSuccess}");
                Debug.WriteLine($"result ErrorMessage: {result.ErrorMessage}");
                if (result.IsSuccess)
                {
                    Debug.WriteLine("Profile updated successfully");
                }
                else
                {
                    Debug.WriteLine($"Failed to update profile: {result.ErrorMessage}");
                }
            }
            catch (ValidationApiException ex)
            {
                Debug.WriteLine($"Validation error: {ex.Content}");
            }
            catch (ApiException ex)
            {
                Debug.WriteLine($"API error: {ex.Content}");
                Debug.WriteLine($"Status Code: {ex.StatusCode}");
                Debug.WriteLine($"Reason Phrase: {ex.ReasonPhrase}");
            }
            catch (Exception ex)
            {
                await ShowErrorAlertAsync(ex.Message);
                Debug.WriteLine($"Error updating profile: {ex.Message}");
            }
        }
    }
}
