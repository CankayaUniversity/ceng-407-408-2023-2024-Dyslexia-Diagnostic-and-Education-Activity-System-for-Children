using DyslexiaAppMAUI.Shared.Dtos;
using Refit;
using System;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.Services
{
    public interface IAuthApi
    {
        [Post("/api/auth/signup")]
        Task<ResultWithDataDto<AuthResponseDto>> SignupAsync(SignupRequestDto dto);

        [Post("/api/auth/signin")]
        Task<ResultWithDataDto<AuthResponseDto>> SigninAsync(SigninRequestDto dto);

        [Put("/api/users/{userId}")]
        Task<ResultWithDataDto<LoggedInUser>> UpdateUserAsync(Guid userId, [Body] UpdateUserDto dto);
    }
}