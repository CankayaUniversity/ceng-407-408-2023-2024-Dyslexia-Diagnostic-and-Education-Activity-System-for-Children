using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DyslexiaApp.MAUI.Pages.Login;
using DyslexiaApp.MAUI.Services;
using DyslexiaAppMAUI.Shared.Dtos;
using DyslexiaAppMAUI.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.ViewModels;
    public partial class AuthViewModel(IAuthApi authApi, AuthService authService) : BaseViewModel
    {
        private readonly IAuthApi _authApi = authApi;
        private readonly AuthService _authService = authService;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignup))]
        private string? _firstName;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignup))] 
        private string? _lastName;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignin)), NotifyPropertyChangedFor(nameof(CanSignup))]
        private string? _email;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignup))]
        private DateTime _birthdate;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignup))]
        private string? _gender;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignin)), NotifyPropertyChangedFor(nameof(CanSignup))]
        private string? _password;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignup))]
        private string? _confirmationPassword;

        public bool CanSignin => !string.IsNullOrEmpty(Email)
                              && !string.IsNullOrEmpty(Password);
        public bool CanSignup => CanSignin
                                  && !string.IsNullOrEmpty(FirstName)
                                  && !string.IsNullOrEmpty(LastName)
                                  && Birthdate != default(DateTime)
                                  && !string.IsNullOrEmpty(Gender)
                                  && !string.IsNullOrEmpty(ConfirmationPassword)
                                  && Password == ConfirmationPassword;

        [RelayCommand]
        private async Task SignupAsync()
        {
            IsBusy = true;
            try
            {
                var signupDto = new SignupRequestDto(FirstName,LastName,Gender, Email, Password, Birthdate);

                var result =await _authApi.SignupAsync(signupDto);

                if(result.IsSuccess)
                {
                    _authService.Signin(result.Data);

                    await GoToAsync($"//{nameof(RegisterAgreement)}", animate: true);
                }
                else
                {
                    await ShowErrorAlertAsync(result.ErrorMessage ?? "Unknown error in singing up");
                }

            }
            catch (Exception ex) 
            { 

                 await ShowErrorAlertAsync(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task SinginAsync()
        {
            IsBusy = true;
            try
            {
                var signinDto = new SigninRequestDto(Email, Password);

                var result = await _authApi.SigninAsync(signinDto);

                if (result.IsSuccess)
                {
                    _authService.Signin(result.Data);
                    await GoToAsync($"//{nameof(HomePage)}", animate: true);
                }
                else
                {
                    await ShowErrorAlertAsync(result.ErrorMessage ?? "Unknown error in singing in");
                }

            }
            catch (Exception ex)
            {

                await ShowErrorAlertAsync(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }