using DyslexiaAppMAUI.Shared.Dtos;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DyslexiaApp.MAUI.Services;
using DyslexiaApp.MAUI.Pages.Login;

namespace DyslexiaApp.MAUI.ViewModels
{
    public class DiagnosisResultViewModel : BaseViewModel
    {
        private readonly IEducationalGameListApi _educationalGameListApi;
        private double accuracyRate;
        private string dyslexiaRate;

        public DiagnosisResultViewModel(IEducationalGameListApi educationalGameListApi)
        {
            _educationalGameListApi = educationalGameListApi;
        }

        public double AccuracyRate
        {
            get => accuracyRate;
            set
            {
                if (accuracyRate != value)
                {
                    accuracyRate = value;
                    OnPropertyChanged();
                }
            }
        }

        public string DyslexiaRate
        {
            get => dyslexiaRate;
            set
            {
                if (dyslexiaRate != value)
                {
                    dyslexiaRate = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task LoadDiagnosisResultAsync(UserAnswersDto userAnswersDto, string email)
        {
            var result = await _educationalGameListApi.SubmitAnswersAsync(userAnswersDto,email);
            AccuracyRate = result.AccuracyRate;
            DyslexiaRate = result.DyslexiaRate;

            
        }
    }
}
