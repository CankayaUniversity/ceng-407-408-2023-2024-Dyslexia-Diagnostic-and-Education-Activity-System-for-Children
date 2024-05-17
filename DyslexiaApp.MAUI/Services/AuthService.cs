using DyslexiaAppMAUI.Shared.Dtos;
using Refit;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.Services
{
    public class AuthService
    {
        private const string AuthKey = "AuthKey";
        public LoggedInUser? User { get; private set; }
        public string? Token { get; private set; }
        public string? ProfileUpdateToken { get; private set; }

        private readonly IAuthApi _authApi;

        public AuthService(IAuthApi authApi)
        {
            _authApi = authApi;
        }

        public async Task<ResultWithDataDto<ProfileUpdateTokenDto>> GenerateProfileUpdateTokenAsync(string email)
        {
            try
            {
                var result = await _authApi.GenerateProfileUpdateTokenAsync(email);
                if (result != null && result.IsSuccess)
                {
                    ProfileUpdateToken = result.Data.Token;
                }
                else
                {
                    Debug.WriteLine($"API call was not successful or result is null. Result: {result}");
                }
                return result;
            }
            catch (ApiException ex)
            {
                Debug.WriteLine($"API error: {ex.Content}");
                Debug.WriteLine($"Status Code: {ex.StatusCode}");
                Debug.WriteLine($"Reason Phrase: {ex.ReasonPhrase}");
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"General error: {ex.Message}");
                throw;
            }
        }

        public async Task<ResultDto> UpdateUserProfileWithTokenAsync(UpdateUserWithTokenDto updateUserWithTokenDto)
        {
            try
            {
                var result = await _authApi.UpdateUserProfileWithTokenAsync(updateUserWithTokenDto);
                Debug.WriteLine($"UpdateUserProfileWithTokenAsync result: {result}");
                return result;
            }
            catch (ApiException ex)
            {
                Debug.WriteLine($"API error: {ex.Content}");
                Debug.WriteLine($"Status Code: {ex.StatusCode}");
                Debug.WriteLine($"Reason Phrase: {ex.ReasonPhrase}");
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"General error: {ex.Message}");
                throw;
            }
        }

        public void Signin(AuthResponseDto dto)
        {
            var serialized = JsonSerializer.Serialize(dto);
            Preferences.Default.Set(AuthKey, serialized);

            (User, Token) = dto;
        }

        public void Initialize()
        {
            if (Preferences.Default.ContainsKey(AuthKey))
            {
                var serialized = Preferences.Default.Get<string?>(AuthKey, null);
                if (string.IsNullOrEmpty(serialized))
                {
                    Preferences.Default.Remove(AuthKey);
                }
                else
                {
                    try
                    {
                        (User, Token) = JsonSerializer.Deserialize<AuthResponseDto>(serialized)!;
                    }
                    catch (JsonException ex)
                    {
                        Debug.WriteLine($"JSON Deserialization Error: {ex.Message}");
                    }
                }
            }
        }

        public void Signout()
        {
            Preferences.Default.Remove(AuthKey);
            (User, Token) = (null, null);
        }
    }
}
