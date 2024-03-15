using DyslexiaApp.API.Data;
using DyslexiaApp.API.Data.Entities;
using DyslexiaAppMAUI.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
namespace DyslexiaApp.API.Services
{
    public class AuthService(AppDbContext context, TokenService tokenService, PasswordService passwordService)
    {
        private readonly AppDbContext _context = context;
        private readonly TokenService _tokenService = tokenService;
        private readonly PasswordService _passwordService = passwordService;


        public async Task <ResultWithDataDto<AuthResponseDto>> SignupAsync(SignupRequestDto dto)
        {
            if(await _context.Users.AsNoTracking().AnyAsync(u=> u.Email == dto.Email))
            {
                return ResultWithDataDto<AuthResponseDto>.Failure("Email already exist");
            }
            
                var user = new User
                {
                    Email = dto.Email,
                    FirstName = dto.Name,
                };

                (user.Salt, user.HashedPassword) = _passwordService.GenerateSaltAndHash(dto.Password);
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return GenerateAuthResponse(user);
            }
            catch (Exception ex) 
            {
                return ResultWithDataDto<AuthResponseDto>.Failure(ex.Message);
            }
        }

       

        public async Task<ResultWithDataDto<AuthResponseDto>> SigninAsync(SigninRequestDto dto)
        {
            var dbUser = await _context.Users
                                .AsNoTracking()
                                .FirstOrDefaultAsync(u  => u.Email == dto.Email);
            if (dbUser == null)
                return ResultWithDataDto<AuthResponseDto>.Failure("User does not exist");
            if(!_passwordService.AreEqual(dto.Password, dbUser.Salt, dbUser.HashedPassword))
                return ResultWithDataDto<AuthResponseDto>.Failure("Incorrect password!");


            return GenerateAuthResponse(dbUser);

        }

        private ResultWithDataDto<AuthResponseDto> GenerateAuthResponse(User user)
        {
            var loggedInUser = new LoggedInUser(user.Id, user.FirstName, user.Email);
            var token = _tokenService.GenerateJwt(loggedInUser);
            var authResponse = new AuthResponseDto(loggedInUser, token);

            return ResultWithDataDto<AuthResponseDto>.Success(authResponse);
        }

    }
}
