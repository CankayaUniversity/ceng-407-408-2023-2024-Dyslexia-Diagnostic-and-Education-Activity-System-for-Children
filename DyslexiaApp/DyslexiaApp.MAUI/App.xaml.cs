using DyslexiaApp.MAUI.Services;

namespace DyslexiaApp.MAUI;

    public partial class App : Application
    {
        public App(AuthService authService)
        {
            InitializeComponent();

            authService.Initialize();

            MainPage = new AppShell(authService);
        }
    }
