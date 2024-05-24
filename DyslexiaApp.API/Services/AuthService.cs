using DyslexiaApp.API.Data;
using DyslexiaApp.API.Data.Entities;
using DyslexiaAppMAUI.Shared.Dtos;
using DyslexiaAppMAUI.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DyslexiaApp.API.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;
        private readonly PasswordService _passwordService;

        public AuthService(AppDbContext context, TokenService tokenService, PasswordService passwordService)
        {
            _context = context;
            _tokenService = tokenService;
            _passwordService = passwordService;
        }

        public async Task<ResultWithDataDto<AuthResponseDto>> SignupAsync(SignupRequestDto dto)
        {
            if (await _context.Users.AsNoTracking().AnyAsync(u => u.Email == dto.Email))
            {
                return ResultWithDataDto<AuthResponseDto>.Failure("Bu e-posta adresi zaten kayıtlı.");
            }

            if (string.IsNullOrWhiteSpace(dto.Password))
            {
                return ResultWithDataDto<AuthResponseDto>.Failure("Şifre boş olamaz.");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                FirstName = dto.Name,
                LastName = dto.LastName,
                Gender = dto.Gender,
                Birthday = dto.Birthday,
                Role = Role.Admin,
                IsActive = true
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
                return ResultWithDataDto<AuthResponseDto>.Failure("Kayıt sırasında bir hata oluştu: " + ex.Message);
            }
        }

        public async Task<ResultWithDataDto<AuthResponseDto>> SigninAsync(SigninRequestDto dto)
        {
            var dbUser = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (dbUser == null)
                return ResultWithDataDto<AuthResponseDto>.Failure("User does not exist");
            if (!_passwordService.AreEqual(dto.Password, dbUser.Salt, dbUser.HashedPassword))
                return ResultWithDataDto<AuthResponseDto>.Failure("Incorrect password!");

            return GenerateAuthResponse(dbUser);
        }

        private ResultWithDataDto<AuthResponseDto> GenerateAuthResponse(User user)
        {
            var loggedInUser = new LoggedInUser(user.Id, user.FirstName, user.Email, user.LastName, user.Birthday, user.Gender);
            var token = _tokenService.GenerateJwt(loggedInUser);
            var authResponse = new AuthResponseDto(loggedInUser, token);

            return ResultWithDataDto<AuthResponseDto>.Success(authResponse);
        }

        public async Task<ResultWithDataDto<LoggedInUser>> UpdateUserAsync(Guid userId, UpdateUserDto dto)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                {
                    return ResultWithDataDto<LoggedInUser>.Failure("Kullanıcı bulunamadı.");
                }

                user.UpdateProfile(dto.FirstName, dto.LastName, dto.Email, dto.Birthday, dto.Gender);

                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                var loggedInUser = new LoggedInUser(user.Id, user.FirstName, user.LastName, user.Email, user.Birthday, user.Gender);
                return ResultWithDataDto<LoggedInUser>.Success(loggedInUser);
            }
            catch (Exception ex)
            {
                // Hata loglaması
                Console.WriteLine($"Hata: {ex.Message}");
                return ResultWithDataDto<LoggedInUser>.Failure("Kullanıcı güncellenirken bir hata oluştu.");
            }
        }
    

    public async Task<ResultDto> DeactivateUserAccountAsync(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return ResultDto.Failure("Kullanıcı bulunamadı!");

            user.IsActive = false;

            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return ResultDto.Success();
            }
            catch (Exception ex)
            {
                return ResultDto.Failure(ex.Message);
            }
        }

        public async Task<ResultWithDataDto<LoggedInUser>> GetUserByIdAsync(Guid userId)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return ResultWithDataDto<LoggedInUser>.Failure("User is not found!");
            }

            var loggedInUser = new LoggedInUser(user.Id, user.FirstName, user.Email, user.LastName, user.Birthday, user.Gender);
            return ResultWithDataDto<LoggedInUser>.Success(loggedInUser);
        }

        public async Task<ResultDto> ChangePassowordAsync(ChangePasswordDto dto, Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user is null)
                return ResultDto.Failure("Invalid request");

            if (!_passwordService.AreEqual(dto.OldPassword, user.Salt, user.HashedPassword))
            {
                return ResultDto.Failure("Incorrect password!");
            }

            (user.Salt, user.HashedPassword) = _passwordService.GenerateSaltAndHash(dto.NewPassword);
            await _context.SaveChangesAsync();

            return ResultDto.Success();
        }

        public async Task<ResultWithDataDto<ResetPasswordRequestDto>> ForgotPasswordAsync(string email, IEmailService emailService)
        {
            var result = await GeneratePasswordResetTokenAsync(email);
            if (!result.IsSuccess)
            {
                return ResultWithDataDto<ResetPasswordRequestDto>.Failure(result.ErrorMessage);
            }

            var resetLink = $"https://localhost:7066/reset-password?token={result.Data.Token}&email={email}";
            await emailService.SendEmailAsync(email, "Şifre Sıfırlama", $"Şifrenizi sıfırlamak için bu linki kullanın: {resetLink}");

            return ResultWithDataDto<ResetPasswordRequestDto>.Success(new ResetPasswordRequestDto { ResetLink = resetLink });
        }

        public async Task<ResultDto> ResetPassword(string token, string newPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.ResetPasswordToken == token && u.ResetPasswordTokenExpiry > DateTime.Now);
            if (user == null)
            {
                return ResultDto.Failure("Invalid or expired reset token.");
            }

            (user.Salt, user.HashedPassword) = _passwordService.GenerateSaltAndHash(newPassword);
            user.ResetPasswordToken = null;
            user.ResetPasswordTokenExpiry = null;
            await _context.SaveChangesAsync();

            return ResultDto.Success();
        }

        public async Task<ResultWithDataDto<AuthResponseDto>> SigninWithGoogleAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                user = new User
                {
                    Id = Guid.NewGuid(),
                    Email = email,
                    IsActive = true
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }

            return GenerateAuthResponse(user);
        }

        public async Task<ResultWithDataDto<PasswordResetTokenDto>> GeneratePasswordResetTokenAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return ResultWithDataDto<PasswordResetTokenDto>.Failure("User does not exist");

            var token = _tokenService.GeneratePasswordResetToken(user.Email);
            user.ResetPasswordToken = token;
            user.ResetPasswordTokenExpiry = DateTimeOffset.UtcNow.AddHours(24).DateTime;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return ResultWithDataDto<PasswordResetTokenDto>.Success(new PasswordResetTokenDto(token));
        }

        public async Task<ResultDto> ResetPasswordAsync(string token, string email, string newPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.ResetPasswordToken == token);
            if (user == null) return ResultDto.Failure("Invalid token or email");

            (user.Salt, user.HashedPassword) = _passwordService.GenerateSaltAndHash(newPassword);
            user.ResetPasswordToken = null;
            await _context.SaveChangesAsync();

            return ResultDto.Success();
        }




    }
}
