﻿using DyslexiaApp.API.Data;
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


        public async Task <ResultWithDataDto<AuthResponseDto>> SignupAsync(SignupRequestDto dto)
        {
            if(await _context.Users.AsNoTracking().AnyAsync(u=> u.Email == dto.Email))
            {
                return ResultWithDataDto<AuthResponseDto>.Failure("Email already exist");
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
            var loggedInUser = new LoggedInUser(user.Id, user.FirstName, user.Email,user.LastName,user.Birthday,user.Gender);
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

    }
}
