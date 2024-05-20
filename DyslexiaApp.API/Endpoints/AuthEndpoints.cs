﻿using DyslexiaApp.API.Services;
using DyslexiaAppMAUI.Shared.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DyslexiaApp.API.Endpoints
{
    public static class AuthEndpoints
    {
        private static Guid GetUserId(this ClaimsPrincipal principal) =>
            Guid.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier)!);

        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
        {
            var tokenService = app.ServiceProvider.GetRequiredService<TokenService>();

            app.MapPost("/api/auth/signup", async (SignupRequestDto dto, AuthService authService) =>
                TypedResults.Ok(await authService.SignupAsync(dto)));

            app.MapPost("/api/auth/signin", async (SigninRequestDto dto, AuthService authService) =>
                TypedResults.Ok(await authService.SigninAsync(dto)));

            app.MapPost("/api/auth/change-password", [Authorize] async (ChangePasswordDto dto, ClaimsPrincipal principal, AuthService authService) =>
                TypedResults.Ok(await authService.ChangePassowordAsync(dto, principal.GetUserId())));

            app.MapPost("/api/dyslexiadiagnosis", async (DyslexiaDiagnosisDto dto, DyslexiaDiagnosisService dyslexiaDiagnosisService) =>
                TypedResults.Ok(await dyslexiaDiagnosisService.AddDyslexiaDiagnosisAsync(dto)));

            app.MapGet("/api/dyslexiadiagnosis", async (DyslexiaDiagnosisService dyslexiaDiagnosisService) =>
                TypedResults.Ok(await dyslexiaDiagnosisService.GetDyslexiaDiagnosesAsync()));

            app.MapPost("/api/educationalgame", async (EducationalDto dto, EducationalGameService educationalGameService) =>
                TypedResults.Ok(await educationalGameService.AddEducationalGameAsync(dto)));

            app.MapGet("/api/educationalgame", async (EducationalGameService educationalGameService) =>
                TypedResults.Ok(await educationalGameService.GetEducationalGamesAsync()));

            var authGroup = app.MapGroup("/api/user").RequireAuthorization();

            authGroup.MapGet("/{userId}", async (Guid userId, AuthService authService, HttpContext httpContext) =>
            {
                var userIdClaim = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userIdClaim) || Guid.Parse(userIdClaim) != userId)
                {
                    return Results.Problem("Yetkisiz erişim.", statusCode: StatusCodes.Status403Forbidden);
                }

                var userResult = await authService.GetUserByIdAsync(userId);
                if (!userResult.IsSuccess)
                {
                    return Results.NotFound("Kullanıcı bulunamadı.");
                }

                return Results.Ok(userResult.Data);
            });

            authGroup.MapPut("/update", async (UserUpdateDto dto, AuthService authService, HttpRequest request) =>
            {
                var userIdClaim = request.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userIdClaim) || Guid.Parse(userIdClaim) != dto.Id)
                {
                    return Results.Problem("Yetkisiz erişim.", statusCode: StatusCodes.Status403Forbidden);
                }

                var result = await authService.UpdateUserProfileAsync(dto);
                if (result.IsSuccess)
                {
                    var updatedUser = await authService.GetUserByIdAsync(dto.Id);
                    return Results.Ok(updatedUser);
                }
                else
                {
                    return Results.Problem(result.ErrorMessage, statusCode: StatusCodes.Status400BadRequest);
                }
            });

            authGroup.MapPost("/generate-profile-update-token", async ([FromQuery] string email, AuthService authService) =>
            {
                var result = await authService.GenerateProfileUpdateTokenAsync(email);
                if (result.IsSuccess)
                {
                    return Results.Ok(result.Data);
                }
                return Results.Problem(result.ErrorMessage, statusCode: StatusCodes.Status400BadRequest);
            }).WithName("GenerateProfileUpdateToken")
            .Produces<ProfileUpdateTokenDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
             .WithTags("User");


            authGroup.MapPut("/update-with-token", async (UpdateUserWithTokenDto dto, AuthService authService) =>
            {
                var result = await authService.UpdateUserProfileWithTokenAsync(dto);
                if (result.IsSuccess)
                {
                    var updatedUser = await authService.GetUserByIdAsync(dto.Id);
                    return Results.Ok(updatedUser.Data);
                }
                return Results.Problem(result.ErrorMessage, statusCode: StatusCodes.Status400BadRequest);
            }).WithName("UpdateUserProfileWithToken")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status400BadRequest)
              .WithTags("User");

            authGroup.MapDelete("/deactivate/{userId}", async (Guid userId, AuthService authService, HttpRequest request) =>
            {
                var userIdClaim = request.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userIdClaim) || Guid.Parse(userIdClaim) != userId)
                {
                    return Results.Problem("Yetkisiz erişim.", statusCode: StatusCodes.Status403Forbidden);
                }

                var result = await authService.DeactivateUserAccountAsync(userId);
                return result.IsSuccess ? Results.NoContent() : Results.Problem(result.ErrorMessage, statusCode: StatusCodes.Status400BadRequest);
            });

            app.MapPost("/api/question", async (QuestionDto dto, QuestionService questionService) =>
            {
                var question = questionService.MapDtoToQuestion(dto);
                return TypedResults.Ok(await questionService.AddQuestionAsync(question));
            });

            app.MapGet("/api/question", async (QuestionService questionService) =>
                TypedResults.Ok(await questionService.GetAllQuestionsAsync()));

            app.MapGet("/api/question/{questionId}", async (Guid questionId, QuestionService questionService) =>
            {
                var question = await questionService.GetQuestionByIdAsync(questionId);
                if (question == null)
                {
                    return Results.NotFound("Question not found.");
                }
                return TypedResults.Ok(question);
            });

            app.MapGet("/api/token", async (HttpContext httpContext, AuthService authService, string email, string password) =>
            {
                var userDto = new SigninRequestDto(email, password);
                var authResult = await authService.SigninAsync(userDto);

                if (!authResult.IsSuccess)
                {
                    return Results.Problem("Kullanıcı adı veya şifre hatalı", statusCode: StatusCodes.Status401Unauthorized);
                }

                var user = new LoggedInUser(authResult.Data.User.Id, authResult.Data.User.Name, authResult.Data.User.LastName, authResult.Data.User.Email, authResult.Data.User.Birthday, authResult.Data.User.Gender);
                var token = tokenService.GenerateJwt(user);

                return Results.Ok(new { Token = token });
            });

            app.MapPost("/api/auth/forgot-password", async (ForgotPasswordRequestDto dto, AuthService authService, IEmailService emailService) =>
            {
                var result = await authService.ForgotPasswordAsync(dto.Email, emailService);
                if (!result.IsSuccess)
                {
                    return Results.BadRequest(new { Error = result.ErrorMessage });
                }
                return Results.Ok();
            }).WithName("ForgotPassword")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status400BadRequest)
              .WithTags("Auth");

            app.MapPost("/api/auth/reset-password", async (ResetPasswordRequestDto dto, AuthService authService) =>
            {
                var result = await authService.ResetPasswordAsync(dto.Token, dto.Email, dto.NewPassword);
                if (!result.IsSuccess)
                {
                    return Results.BadRequest(new { Error = result.ErrorMessage });
                }
                return Results.Ok();
            }).WithName("ResetPassword")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status400BadRequest)
              .WithTags("Auth");

            return app;
        }
    }
}
