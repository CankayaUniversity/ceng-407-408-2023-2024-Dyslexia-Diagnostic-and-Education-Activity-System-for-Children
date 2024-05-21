using DyslexiaApp.MAUI.ViewModels;

namespace DyslexiaApp.MAUI.Pages.Login
{
    public partial class EducationalGameList : ContentPage
    {
        private readonly EducationalGamesViewModel _educationalGamesViewModel;

        public EducationalGameList(EducationalGamesViewModel educationalGamesViewModel)
        {
            InitializeComponent();
            _educationalGamesViewModel = educationalGamesViewModel;
            BindingContext = _educationalGamesViewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing(); // Call base.OnAppearing to ensure any base class logic is executed
            _educationalGamesViewModel.ResetPopupVisibility(); // Reset the popup visibility
            await _educationalGamesViewModel.InitializeAsync(); // Initialize the view model
        }

        private async void Home_Button(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}