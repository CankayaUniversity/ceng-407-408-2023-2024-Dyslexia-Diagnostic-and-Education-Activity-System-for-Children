using DyslexiaAppMAUI.Shared.Dtos;
using Org.BouncyCastle.Asn1.Ocsp;
using Refit;
using System;
using System.Diagnostics;
using System.Net.Http;
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

        public async Task<ResultWithDataDto<ResetPasswordRequestDto>> ForgotPasswordAsync(string email)
        {
            try
            {
                var dto = new ForgotPasswordRequestDto { Email = email };
                var response = await _authApi.ForgotPasswordAsync(dto);
                if (response.IsSuccess)
                {
                    var resetLink = $"https://localhost:7066/resetpassword?token={response.Data.Token}&email={email}";
                    return ResultWithDataDto<ResetPasswordRequestDto>.Success(new ResetPasswordRequestDto { ResetLink = resetLink });
                }
                return ResultWithDataDto<ResetPasswordRequestDto>.Failure(response.ErrorMessage);
            }
            catch (Exception ex)
            {
                return ResultWithDataDto<ResetPasswordRequestDto>.Failure(ex.Message);
            }
        }





        public async Task<bool> ResetPasswordAsync(string token, string email, string newPassword)
        {
            try
            {
                var dto = new ResetPasswordRequestDto
                {
                    Token = token,
                    Email = email,
                    NewPassword = newPassword
                };
                var response = await _authApi.ResetPasswordAsync(dto);
                return response.IsSuccess;
            }
            catch
            {
                return false;
            }
        }
    }
}