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
            .ConfigureHttpClient(HttpClient =>
            {
                var baseUrl = DeviceInfo.Platform == DevicePlatform.WinUI
                                ? "https://127.0.0.1:7066"
                                : "https://localhost:7066";

                HttpClient.BaseAddress = new Uri(baseUrl);
            });
    }
}