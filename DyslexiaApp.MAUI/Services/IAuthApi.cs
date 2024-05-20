using DyslexiaAppMAUI.Shared.Dtos;
using Refit;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.Services
{
    public interface IAuthApi
    {

        [Post("/api/auth/signup")]
        Task<ResultWithDataDto<AuthResponseDto>> SignupAsync(SignupRequestDto dto);

        [Post("/api/auth/signin")]
        Task<ResultWithDataDto<AuthResponseDto>> SigninAsync(SigninRequestDto dto);

        [Post("/api/user/generate-profile-update-token")]
        Task<ResultWithDataDto<ProfileUpdateTokenDto>> GenerateProfileUpdateTokenAsync([Query] string email);

        [Put("/api/user/update-with-token")]
        Task<ResultDto> UpdateUserProfileWithTokenAsync(UpdateUserWithTokenDto updateUserWithTokenDto);
    }
}

