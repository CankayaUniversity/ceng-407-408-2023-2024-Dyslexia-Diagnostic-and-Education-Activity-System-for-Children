using DyslexiaApp.MAUI.ViewModels;

namespace DyslexiaApp.MAUI.Pages.Login
{
    public partial class DiagnosisLetterMatchingInformation : ContentPage
    {
        private readonly DiagnosisMatchingGamesViewModel _diagnosisMatchingViewModel;

        public DiagnosisLetterMatchingInformation(DiagnosisMatchingGamesViewModel diagnosisMatchingViewModel)
        {
            InitializeComponent();
            _diagnosisMatchingViewModel = diagnosisMatchingViewModel;
            BindingContext = _diagnosisMatchingViewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            _diagnosisMatchingViewModel.ResetLetter();
            await _diagnosisMatchingViewModel.SelectDefaultGame0();
        }


        private async void Close_Button(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}