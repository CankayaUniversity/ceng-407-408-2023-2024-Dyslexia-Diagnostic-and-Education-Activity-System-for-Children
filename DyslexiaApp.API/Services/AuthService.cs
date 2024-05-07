using DyslexiaApp.API.Data;
using DyslexiaApp.API.Data.Entities;
using DyslexiaAppMAUI.Shared.Dtos;
using DyslexiaAppMAUI.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
namespace DyslexiaApp.API.Services
{
    public class AuthService(AppDbContext context, TokenService tokenService, PasswordService passwordService)
    {
        private readonly AppDbContext _context = context;
        private readonly TokenService _tokenService = tokenService;
        private readonly PasswordService _passwordService = passwordService;


        public async Task<ResultWithDataDto<AuthResponseDto>> SignupAsync(SignupRequestDto dto)
        {
            var Received = dto.Password;
            // E-posta adresi zaten kayıtlı mı diye kontrol edilir
            if (await _context.Users.AsNoTracking().AnyAsync(u => u.Email == dto.Email))
            {
                return ResultWithDataDto<AuthResponseDto>.Failure("Bu e-posta adresi zaten kayıtlı.");
            }

            // Şifrenin boş veya null olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(dto.Password))
            {
                return ResultWithDataDto<AuthResponseDto>.Failure("Şifre boş olamaz.");
            }

            // Yeni kullanıcı nesnesi oluştur
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

            // Şifre için tuz ve hash oluştur
            (user.Salt, user.HashedPassword) = _passwordService.GenerateSaltAndHash(dto.Password);

            // Kullanıcıyı veritabanına ekle
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
            var dbUser = await _context.Users
                                .AsNoTracking()
                                .FirstOrDefaultAsync(u => u.Email == dto.Email);
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

        // Kullanıcı profili güncelleme metodu
        public async Task<ResultDto> UpdateUserProfileAsync(UserUpdateDto updateDto)
        {
            var user = await _context.Users.FindAsync(updateDto.Id);
            if (user == null) return ResultDto.Failure("Kullanıcı bulunamadı!");

            user.FirstName = updateDto.FirstName;
            user.LastName = updateDto.LastName;
            user.Email = updateDto.Email;
            user.Birthday = updateDto.Birthday;
            user.Gender = updateDto.Gender;
            // Eğer şifre güncellenmesine izin verilecekse, burada şifre güncelleme işlemi yapılabilir.

            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return ResultDto.Success();
            }
            catch (Exception ex)
            {
                // Log the exception if you have logging in place.
                return ResultDto.Failure(ex.Message);
            }
        }


        // Kullanıcı hesabını devre dışı bırakma metodu
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
                // Log the exception if you have logging in place.
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
            var user = await _context.Users.FirstOrDefaultAsync(u=> u.Id == userId);
            if (user is null)
                return ResultDto.Failure("Invalid request");

            if(!_passwordService.AreEqual(dto.OldPassword, user.Salt, user.HashedPassword))
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

            // Update the password
            (user.Salt, user.HashedPassword) = _passwordService.GenerateSaltAndHash(newPassword);
            user.ResetPasswordToken = null; // Clear the reset token
            user.ResetPasswordTokenExpiry = null;

            await _context.SaveChangesAsync();

            return ResultDto.Success();
        }

        public async Task<ResultWithDataDto<AuthResponseDto>> SigninWithGoogleAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            // Eğer kullanıcı mevcut değilse, yeni bir kullanıcı oluştur
            if (user == null)
            {
                user = new User
                {
                    Id = Guid.NewGuid(),
                    Email = email,
                    IsActive = true // Diğer gerekli alanlar varsayılan değerlerle doldurulabilir
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }

            // Oturum açma işleminin geri dönüş değeri
            return GenerateAuthResponse(user);
        }

        public async Task<ResultWithDataDto<PasswordResetTokenDto>> GeneratePasswordResetTokenAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return ResultWithDataDto<PasswordResetTokenDto>.Failure("User does not exist");

            // Doğru parametre ile GeneratePasswordResetToken metodunu çağır
            var token = _tokenService.GeneratePasswordResetToken(user.Email);  // Burada user.Email kullanılmalı

            // Token'ı veritabanında bir yerde saklayın veya kullanıcı ile ilişkilendirin
            // Örnek olarak, user nesnesine token ve zaman damgası ekleyebilirsiniz.
            user.ResetPasswordToken = token;
            user.ResetPasswordTokenExpiry = DateTimeOffset.UtcNow.AddHours(24).DateTime;  // Convert DateTimeOffset to DateTime

            // Değişiklikleri veritabanına kaydet
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return ResultWithDataDto<PasswordResetTokenDto>.Success(new PasswordResetTokenDto(token));
        }

        public async Task<ResultDto> ResetPasswordAsync(string token, string email, string newPassword)
        {
            // Token ve e-posta adresini doğrulayın
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.ResetPasswordToken == token);
            if (user == null) return ResultDto.Failure("Invalid token or email");

            // Şifreyi güncelleyin
            (user.Salt, user.HashedPassword) = _passwordService.GenerateSaltAndHash(newPassword);
            user.ResetPasswordToken = null; // Token'ı sıfırla veya geçersiz kıl
            await _context.SaveChangesAsync();

            return ResultDto.Success();
        }

    }
}