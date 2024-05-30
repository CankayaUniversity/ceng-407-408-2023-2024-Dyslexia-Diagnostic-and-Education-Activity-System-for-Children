using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Refit;
using DyslexiaApp.MAUI.Services;
using DyslexiaApp.MAUI.ViewModels;
using DyslexiaApp.MAUI.Pages.Login;
using System.Net.Security;
using DyslexiaAppMAUI.Shared;


#if ANDROID
using Xamarin.Android.Net;
using System.Net.Http;
#elif IOS
using Security;
using Foundation;
#endif

namespace DyslexiaApp.MAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddTransient<AuthViewModel>()
                        .AddTransient<Register>()
                        .AddTransient<LoginPage>();

        builder.Services.AddSingleton<AuthService>();

        builder.Services.AddSingleton<DiagnosisMatchingGamesViewModel>()  
                        .AddSingleton<EducationalGameList>();

        builder.Services.AddTransient<MatchingViewModel>();
                        

        builder.Services.AddTransient<MatchingViewModel>()
                        .AddTransient<PlayGame>();

        //builder.Services.AddTransient<EducationalGamesViewModel>()
        //    .AddTransient<DiagnosisLetterMatchingInformation>();

        builder.Services.AddSingleton<DiagnosisMatchingGamesViewModel>()
            .AddTransient<DiagnosisLetterMatchingInformation>();

        builder.Services.AddTransient<LetterMatchingViewModel>()
            .AddTransient<LetterMatchingGame>();

        builder.Services.AddSingleton<DiagnosisNavigationViewModel>()
                .AddTransient<DiagnosisNavigationInfo>();

        builder.Services.AddTransient<NavigationSkillsGame>();

        builder.Services.AddSingleton<ProfileViewModel>()
                        .AddSingleton<ProfilePage>();

        builder.Services.AddTransient<ChatViewModel>()
                        .AddTransient<HomePage>()
                        .AddTransient<IOpenAIService, OpenAIService>();

        builder.Services.AddTransient<ForgotPasswordViewModel>()
                        .AddTransient<ForgotPassword>();

        builder.Services.AddTransient<ResetPasswordViewModel>()
                        .AddTransient<ResetPasswordPage>();

        builder.Services.AddSingleton<EducationalGamesViewModel>()
                .AddSingleton<EducationalResultPage>();

        builder.Services.AddTransient<DiagnosisNavigationInfo>();

        builder.Services.AddSingleton<NavigationGameViewModel>()
                        .AddTransient<NavigationSkillsGame>();

        builder.Services.AddSingleton<DiagnosisMatchingGamesViewModel>()
                        .AddTransient<DiagnosisSymmetryInfo>();

        builder.Services.AddTransient<SymmetryTestViewModel>()
                        .AddTransient<SymmetryGameTest>();

        builder.Services.AddSingleton<DiagnosisResultPage>();     
        builder.Services.AddTransient<DiagnosisResultViewModel>();
        builder.Services.AddTransient<DyslexiaResultDto>();


         
        ConfigureRefit(builder.Services);

        return builder.Build();
    }
    private static void ConfigureRefit(IServiceCollection services)
    {
        var refitSettings = new RefitSettings
        {
            HttpMessageHandlerFactory = () =>
            {
#if ANDROID
                return new AndroidMessageHandler
                {
                    ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
                    {
                        // Sertifika doğrulamasını geçici olarak devre dışı bırakıyoruz.
                        return true;
                    }
                };
#elif IOS
                return new NSUrlSessionHandler
                {
                    TrustOverrideForUrl = (NSUrlSessionHandler sender, string url, SecTrust trust) =>
                    {
                        // iOS için sertifika doğrulamasını geçici olarak devre dışı bırakıyoruz.
                        return url.StartsWith("https://localhost");
                    }
                };
#elif WINDOWS
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
                {
                    // Windows için sertifika doğrulamasını geçici olarak devre dışı bırakıyoruz.
                    if (request.RequestUri.Host.Equals("https://localhost") || request.RequestUri.Host.Equals("127.0.0.1"))
                    {
                        return true;
                    }
                    return errors == SslPolicyErrors.None;
                };
                return handler;
#endif
                return null;
            }
        };

        services.AddRefitClient<IAuthApi>(refitSettings)
             .ConfigureHttpClient(SetHttpClient);

        services.AddRefitClient<IEducationalGameListApi>(refitSettings)
            .ConfigureHttpClient(SetHttpClient);

        services.AddRefitClient<IPictureMatchingApi>(refitSettings)
            .ConfigureHttpClient(SetHttpClient);
    }

    private static void SetHttpClient(HttpClient httpClient)
    {
        var baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                               ? "https://10.0.2.2:7066"
                               : "https://localhost:7066";

        if (DeviceInfo.DeviceType == DeviceType.Physical)
        {
            baseUrl = "https://4r0lbx2t-7066.euw.devtunnels.ms";
        }

        httpClient.BaseAddress = new Uri(baseUrl);
    }
}

