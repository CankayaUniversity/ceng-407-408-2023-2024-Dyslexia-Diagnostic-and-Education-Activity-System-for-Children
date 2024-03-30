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
           async (DyslexiaDiagnosisService dyslexiaDiagnosisService) =>
           TypedResults.Ok(await dyslexiaDiagnosisService.GetDyslexiaDiagnosesAsync()));
        return app;
      }
   }

