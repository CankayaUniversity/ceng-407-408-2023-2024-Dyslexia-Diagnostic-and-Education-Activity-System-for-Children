﻿//using Android.OS;
//using Java.Util.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Refit;
using System.Net.Security;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;
using DyslexiaApp.MAUI.Services;
using DyslexiaApp.MAUI.ViewModels;
using DyslexiaApp.MAUI.Pages.Login;

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

        builder.Services.AddTransient<AuthService>();

        builder.Services.AddSingleton<EducationalGamesViewModel>()
                        .AddSingleton<EducationalGameList>();

        builder.Services.AddTransient<PictureMatchingViewModel>()
                        .AddTransient<PictureMatchingGame>();

        //builder.Services.AddSingleton<IPictureMatchingApi, IPictureMatchingApi>();  // Ensure your implementation class is correctly named
        //builder.Services.AddSingleton<PictureMatchingViewModel>();

        builder.Services.AddSingleton<ProfileViewModel>()
                        .AddSingleton<ProfilePage>();

        builder.Services.AddTransient<ChatViewModel>()
            .AddTransient<HomePage>();

        ConfigureRefit(builder.Services);

        return builder.Build();
    }
    private static void ConfigureRefit(IServiceCollection services)
    {
        var refitSettings = new RefitSettings
        {

            HttpMessageHandlerFactory = () =>
            {
                var handler = new HttpClientHandler();

#if DEBUG
                handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
                {
                    if (request.RequestUri.Host.Equals("https://localhost") || request.RequestUri.Host.Equals("127.0.0.1"))
                    {
                        return true;
                    }
                    return errors == SslPolicyErrors.None;
                };
#endif
                return handler;
            }
        };
        services.AddRefitClient<IAuthApi>(refitSettings)
            .ConfigureHttpClient(SetHttpClient);

        services.AddRefitClient<IEducationalGameListApi>(refitSettings)
            .ConfigureHttpClient(SetHttpClient);

        services.AddRefitClient<IPictureMatchingApi>(refitSettings)
            .ConfigureHttpClient(SetHttpClient);


        static void SetHttpClient(HttpClient httpClient)
        {
            var baseUrl = DeviceInfo.Platform == DevicePlatform.WinUI
                               ? "https://127.0.0.1:7066"
                               : "https://localhost:7066";

            if (DeviceInfo.DeviceType == DeviceType.Physical)
            {
                baseUrl = "https://32c00r8v-7066.euw.devtunnels.ms";
            }

            httpClient.BaseAddress = new Uri(baseUrl);

        }

    }
}