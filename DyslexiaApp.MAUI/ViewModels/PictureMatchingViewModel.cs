using CommunityToolkit.Mvvm.ComponentModel;
using DyslexiaAppMAUI.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.ViewModels;

[QueryProperty(nameof(Question), nameof(Question))]



public partial class PictureMatchingViewModel : BaseViewModel
{
    [ObservableProperty]
    private QuestionDto? _question;

}