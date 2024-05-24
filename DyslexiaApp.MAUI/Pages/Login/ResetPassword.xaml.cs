using DyslexiaApp.MAUI.Services;
using DyslexiaApp.MAUI.ViewModels;
using Microsoft.Maui.Controls;
using System;
using System.Web;

namespace DyslexiaApp.MAUI.Pages.Login
{
    public partial class ResetPassword : ContentPage
    {
        public ResetPassword(ResetPasswordViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var uri = new Uri(Shell.Current.CurrentState.Location.OriginalString);
            var query = HttpUtility.ParseQueryString(uri.Query);

            ((ResetPasswordViewModel)BindingContext).Token = query.Get("token");
            ((ResetPasswordViewModel)BindingContext).Email = query.Get("email");
        }
    }
}
