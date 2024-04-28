using DyslexiaApp.MAUI.ViewModels;
using DyslexiaAppMAUI.Shared.Dtos;
using System;

namespace DyslexiaApp.MAUI.Pages.Login;

//[QueryProperty(nameof(QuestionId), "QuestionId")]
public partial class PictureMatchingGame : ContentPage
{
    private readonly PictureMatchingViewModel _pictureViewModel;

    //private string _questionId;

    public PictureMatchingGame(PictureMatchingViewModel pictureViewModel)
    {
        InitializeComponent();
        _pictureViewModel = pictureViewModel;
        BindingContext = _pictureViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        Guid questionId = Guid.Parse("0d3cf82d-9a81-4ffd-abdc-ce2da4857a52");
        await _pictureViewModel.InitializeAsync(questionId);
    }

    private async void Home_Button(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}