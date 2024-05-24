namespace DyslexiaApp.MAUI.Pages.Login
{
    public partial class ForgotPassword : ContentPage
    {
        private readonly ForgotPasswordViewModel _viewModel;

        public ForgotPassword(ForgotPasswordViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = viewModel;
        }

        private void EmailEntry_Unfocused(object sender, FocusEventArgs e)
        {
            // Handle the unfocused event here.
            var email = ((Entry)sender).Text;
            // You can add validation or other logic here if needed
        }

        private async void OnSendEmailButtonClicked(object sender, EventArgs e)
        {
            // Komutun çalýþtýrýlabilir olup olmadýðýný kontrol edin
            if (_viewModel.ForgotPasswordCommand.CanExecute(null))
            {
                // Komutu çalýþtýrýn
                _viewModel.ForgotPasswordCommand.Execute(null);
            }
        }

        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            // Close the current modal or navigate back
            Navigation.PopModalAsync();
        }
    }
}