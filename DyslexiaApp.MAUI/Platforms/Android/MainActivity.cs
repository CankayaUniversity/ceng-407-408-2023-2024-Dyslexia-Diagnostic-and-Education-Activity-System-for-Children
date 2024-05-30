using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace DyslexiaApp.MAUI
{
    [Activity(Theme = "@style/Maui.SplashTheme",
              MainLauncher = true,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density,
              ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Sertifika doğrulamasını geçici olarak devre dışı bırakma (güvenli değil, sadece geliştirme için kullanın)
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        }
    }
}