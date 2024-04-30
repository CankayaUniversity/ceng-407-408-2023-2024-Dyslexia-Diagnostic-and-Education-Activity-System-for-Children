using DyslexiaApp.API.Services;
using DyslexiaAppMAUI.Shared.Dtos;
using System.Security.Claims;

namespace DyslexiaApp.API.Endpoints;

public static class AuthEndpoints
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {

        var tokenService = app.ServiceProvider.GetRequiredService<TokenService>();
        app.MapPost("/api/signup",
            async (SignupRequestDto dto, AuthService authService) =>
                TypedResults.Ok(await authService.SignupAsync(dto)));

        app.MapPost("/api/signin",
            async (SigninRequestDto dto, AuthService authService) =>
                TypedResults.Ok(await authService.SigninAsync(dto)));

        app.MapPost("/api/dyslexiadiagnosis",
            async (DyslexiaDiagnosisDto dto, DyslexiaDiagnosisService dyslexiaDiagnosisService) =>
                TypedResults.Ok(await dyslexiaDiagnosisService.AddDyslexiaDiagnosisAsync(dto))); // Düzeltildi: Yeni bir dyslexia tanısı ekler

        app.MapGet("/api/dyslexiadiagnosis",
            async (DyslexiaDiagnosisService dyslexiaDiagnosisService) =>
                TypedResults.Ok(await dyslexiaDiagnosisService.GetDyslexiaDiagnosesAsync())); // Var olan dyslexia tanılarını getirir

        app.MapPost("/api/educationalgame",
            async (EducationalDto dto, EducationalGameService educationalGameService) =>
                TypedResults.Ok(await educationalGameService.AddEducationalGameAsync(dto))); // Düzeltildi: Yeni bir eğitici oyun ekler

        app.MapGet("/api/educationalgame",
            async (EducationalGameService educationalGameService) =>
                TypedResults.Ok(await educationalGameService.GetEducationalGamesAsync())); // Var olan eğitici oyunları getirir

        // Kullanıcı Bilgilerini Getirme Endpoint'i
        app.MapGet("/api/user/{userId}", async (Guid userId, AuthService authService, HttpContext httpContext) =>
        {
            // Yetki kontrolü burada gerçekleştirilebilir.
            var userIdClaim = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim) || Guid.Parse(userIdClaim) != userId)
            {
                return Results.Problem("Yetkisiz erişim.", statusCode: StatusCodes.Status403Forbidden);
            }

            // Kullanıcı bilgilerini getir
            var userResult = await authService.GetUserByIdAsync(userId);
            if (!userResult.IsSuccess)
            {
                return Results.NotFound("Kullanıcı bulunamadı.");
            }

            return Results.Ok(userResult.Data);
        });



        app.MapPut("/api/user/update", async (UserUpdateDto dto, AuthService authService, HttpRequest request) =>
        {
            // Yetki kontrolü burada gerçekleştirilebilir.
            var userIdClaim = request.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim) || Guid.Parse(userIdClaim) != dto.Id)
            {
                return Results.Problem("Yetkisiz erişim.", statusCode: StatusCodes.Status403Forbidden);
            }

            var result = await authService.UpdateUserProfileAsync(dto);
            if (result.IsSuccess)
            {
                var updatedUser = await authService.GetUserByIdAsync(dto.Id); // Bu metod, güncellenmiş kullanıcıyı döndürmelidir.
                return Results.Ok(updatedUser);
            }
            else
            {
                return Results.Problem(result.ErrorMessage, statusCode: StatusCodes.Status400BadRequest);
            }
        });


        // Kullanıcı Hesabını Devre Dışı Bırakma
        app.MapDelete("/api/user/deactivate/{userId}", async (Guid userId, AuthService authService, HttpRequest request) =>
        {
            // Yetki kontrolü burada gerçekleştirilebilir.
            var userIdClaim = request.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim) || Guid.Parse(userIdClaim) != userId)
            {
                return Results.Problem("Yetkisiz erişim.", statusCode: StatusCodes.Status403Forbidden);
            }

            var result = await authService.DeactivateUserAccountAsync(userId);
            return result.IsSuccess ? Results.NoContent() : Results.Problem(result.ErrorMessage, statusCode: StatusCodes.Status400BadRequest);
        });

        app.MapPost("/api/question",
            async (QuestionDto dto, QuestionService questionService) =>
            {
                var question = questionService.MapDtoToQuestion(dto); // Convert DTO to Entity
                return TypedResults.Ok(await questionService.AddQuestionAsync(question));
            });


        // Endpoint to get all questions
        app.MapGet("/api/question",
            async (QuestionService questionService) =>
                TypedResults.Ok(await questionService.GetAllQuestionsAsync()));

        // Endpoint to get a single question by ID
        app.MapGet("/api/question/{questionId}",
            async (Guid questionId, QuestionService questionService) =>
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
            // Kullanıcı adı ve şifre ile kullanıcıyı doğrula
            var userDto = new SigninRequestDto(email, password);
            var authResult = await authService.SigninAsync(userDto);

            if (!authResult.IsSuccess)
            {
                return Results.Problem("Kullanıcı adı veya şifre hatalı", statusCode: StatusCodes.Status401Unauthorized);
            }

            // Token oluştur
            var user = new LoggedInUser(authResult.Data.User.Id, authResult.Data.User.Name, authResult.Data.User.LastName, authResult.Data.User.Email, authResult.Data.User.Birthday, authResult.Data.User.Gender);
            var token = tokenService.GenerateJwt(user);

            return Results.Ok(new { Token = token });
        });


        return app;
    }
}