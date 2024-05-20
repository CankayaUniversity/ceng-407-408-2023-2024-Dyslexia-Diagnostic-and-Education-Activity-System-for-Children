using DyslexiaAppMAUI.Shared.Dtos;
using Refit;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
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
        private readonly HttpClient _httpClient;

        public AuthService(IAuthApi authApi, HttpClient httpClient)
        {
            _authApi = authApi ?? throw new ArgumentNullException(nameof(authApi));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<ResultWithDataDto<ProfileUpdateTokenDto>> GenerateProfileUpdateTokenAsync(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(Token))
                {
                    Debug.WriteLine("Token is null or empty.");
                    throw new UnauthorizedAccessException("Token is required.");
                }

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                Debug.WriteLine($"Calling API to generate profile update token for email: {email}");

                var result = await _authApi.GenerateProfileUpdateTokenAsync(email);
                if (result != null && result.IsSuccess)
                {
                    ProfileUpdateToken = result.Data.Token;
                    Debug.WriteLine($"Token generated successfully: {ProfileUpdateToken}");
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

                if (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Debug.WriteLine("Unauthorized: Token might be invalid or expired.");
                }

                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine($"Unauthorized error: {ex.Message}");
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
                if (string.IsNullOrEmpty(Token))
                {
                    Debug.WriteLine("Token is null or empty.");
                    throw new UnauthorizedAccessException("Token is required.");
                }

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

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
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine($"Unauthorized error: {ex.Message}");
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
                if (!string.IsNullOrEmpty(serialized))
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
                else
                {
                    Preferences.Default.Remove(AuthKey);
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
