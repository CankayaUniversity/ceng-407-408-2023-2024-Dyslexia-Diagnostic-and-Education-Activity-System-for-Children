using DyslexiaApp.API.Services;
using DyslexiaAppMAUI.Shared.Dtos;

namespace DyslexiaApp.API.Endpoints;

public static class AuthEndpoints
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {
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

        return app;
    }
}