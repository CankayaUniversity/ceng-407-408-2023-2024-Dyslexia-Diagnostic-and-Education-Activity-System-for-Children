using DyslexiaApp.MAUI.ViewModels;

namespace DyslexiaApp.MAUI.Pages.Login
{
    public partial class EducationalGameList : ContentPage
    {
        private readonly DiagnosisMatchingGamesViewModel _diagnosisMatchingGamesViewModel;

        public EducationalGameList(DiagnosisMatchingGamesViewModel diagnosisMatchingGamesViewModel)
        {
            InitializeComponent();
            _diagnosisMatchingGamesViewModel = diagnosisMatchingGamesViewModel;
            BindingContext = _diagnosisMatchingGamesViewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing(); // Call base.OnAppearing to ensure any base class logic is executed
            _diagnosisMatchingGamesViewModel.ResetPopupVisibility(); // Reset the popup visibility
            await _diagnosisMatchingGamesViewModel.SelectDefaultGame2(); // Initialize the view model
        }

        private async void Home_Button(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}