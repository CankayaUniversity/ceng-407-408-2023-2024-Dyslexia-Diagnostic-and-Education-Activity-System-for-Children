using DyslexiaApp.API.Services;
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

            app.MapPost("/api/auth/send-verification-code", async (ForgotPasswordRequestDto dto, AuthService authService) =>
            {
                var result = await authService.SendVerificationCodeAsync(dto.Email);
                return TypedResults.Ok(result);
            });

            app.MapPost("/api/auth/verify-code", async (VerifyCodeRequestDto dto, AuthService authService) =>
            {
                var result = await authService.VerifyCodeAsync(dto.Email, dto.Code);
                return TypedResults.Ok(result);
            });

            app.MapPost("/api/auth/change-password", [Authorize] async (ChangePasswordDto dto, ClaimsPrincipal principal, AuthService authService) =>
                TypedResults.Ok(await authService.ChangePassowordAsync(dto, principal.GetUserId())));

            app.MapPost("/api/dyslexiadiagnosis", async (DyslexiaDiagnosisDto dto, DyslexiaDiagnosisService dyslexiaDiagnosisService) =>
                TypedResults.Ok(await dyslexiaDiagnosisService.AddDyslexiaDiagnosisAsync(dto)));

            app.MapGet("/api/dyslexiadiagnosis", async (DyslexiaDiagnosisService dyslexiaDiagnosisService) =>
                TypedResults.Ok(await dyslexiaDiagnosisService.GetDyslexiaDiagnosesAsync()));

            app.MapGet("/api/navigationgame/start", async (HttpContext httpContext, [FromServices] NavigationGameService navigationGameService) =>
            {
                try
                {
                    var navigationGame = await navigationGameService.StartGameAsync();
                    await httpContext.Response.WriteAsJsonAsync(navigationGame);
                }
                catch (Exception ex)
                {
                    httpContext.Response.StatusCode = 400; // Bad Request
                    await httpContext.Response.WriteAsync($"Error: {ex.Message}");
                }
            });


            app.MapPost("/api/educationalgame", async (EducationalDto dto, EducationalGameService educationalGameService) =>
                TypedResults.Ok(await educationalGameService.AddEducationalGameAsync(dto)));

            app.MapGet("/api/educationalgame", async (EducationalGameService educationalGameService) =>
                TypedResults.Ok(await educationalGameService.GetEducationalGamesAsync()));

            

            var authGroup = app.MapGroup("/api/user").RequireAuthorization();
            app.MapPut("/api/user/update", async (UpdateUserDto dto, ClaimsPrincipal principal, AuthService authService) =>
            {
                var userId = principal.GetUserId();
                var result = await authService.UpdateUserAsync(userId, dto);

                if (!result.IsSuccess)
                {
                    return Results.BadRequest(new { Error = result.ErrorMessage });
                }

                return Results.Ok(result.Data);
            });

           

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
