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

        private readonly IAuthApi _authApi;

        public AuthService(IAuthApi authApi)
        {
            _authApi = authApi;
        }

        public void Signin(AuthResponseDto dto)
        {
            var serialized = JsonSerializer.Serialize(dto);
            Preferences.Default.Set(AuthKey, serialized);

            User = dto.User;
            Token = dto.Token;
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
                        var dto = JsonSerializer.Deserialize<AuthResponseDto>(serialized)!;
                        User = dto.User;
                        Token = dto.Token;
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
            User = null;
            Token = null;
        }

        public async Task<ResultWithDataDto<LoggedInUser>> UpdateUserAsync(Guid userId, UpdateUserDto dto)
        {
            try
            {
                var result = await _authApi.UpdateUserAsync(userId, dto);
                if (result.IsSuccess)
                {
                    User = result.Data;
                    return new ResultWithDataDto<LoggedInUser>(true, result.Data, null);
                }
                return new ResultWithDataDto<LoggedInUser>(false, null, result.ErrorMessage);
            }
            catch (ApiException ex)
            {
                Debug.WriteLine($"API Exception: {ex.Message}");
                return new ResultWithDataDto<LoggedInUser>(false, null, ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
                return new ResultWithDataDto<LoggedInUser>(false, null, ex.Message);
            }
        }

        public async Task<ResultWithDataDto<ResetPasswordRequestDto>> ResetPasswordAsync(string verificationCode, string email, string newPassword)
        {
            try
            {
                var dto = new ResetPasswordRequestDto
                {
                    VerificationCode = verificationCode,
                    Email = email,
                    NewPassword = newPassword
                };
                var response = await _authApi.ResetPasswordAsync(dto);
                return response;
            }
            catch (Exception ex)
            {
                return ResultWithDataDto<ResetPasswordRequestDto>.Failure(ex.Message);
            }
        }



        public async Task<ResultDto> SendVerificationCodeAsync(string email)
        {
            try
            {
                Debug.WriteLine($"Sending verification code to {email}");
                var result = await _authApi.SendVerificationCodeAsync(new ForgotPasswordRequestDto { Email = email });
                Debug.WriteLine($"Result: {result.IsSuccess}, Error: {result.ErrorMessage}");
                return result;
            }
            catch (ApiException ex)
            {
                // Log the exception details
                Debug.WriteLine($"API Exception: {ex.Message}");
                if (ex.Content != null)
                {
                    Debug.WriteLine($"API Response Content: {ex.Content}");
                }
                return ResultDto.Failure(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
                return ResultDto.Failure(ex.Message);
            }
        }

        public async Task<ResultDto> VerifyCodeAsync(string email, string code)
        {
            try
            {
                Debug.WriteLine($"Verifying code for {email} with code {code}");
                var result = await _authApi.VerifyCodeAsync(new VerifyCodeRequestDto { Email = email, Code = code });
                Debug.WriteLine($"Result: {result.IsSuccess}, Error: {result.ErrorMessage}");
                return result;
            }
            catch (ApiException ex)
            {
                // Log the exception details
                Debug.WriteLine($"API Exception: {ex.Message}");
                if (ex.Content != null)
                {
                    Debug.WriteLine($"API Response Content: {ex.Content}");
                }
                return ResultDto.Failure(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
                return ResultDto.Failure(ex.Message);
            }


        }

        
    }
}
