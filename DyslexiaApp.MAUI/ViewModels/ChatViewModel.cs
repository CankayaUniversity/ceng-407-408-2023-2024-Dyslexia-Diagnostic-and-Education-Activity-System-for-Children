using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DyslexiaApp.MAUI.Services;
using DyslexiaApp.MAUI.Models;

namespace DyslexiaApp.MAUI.ViewModels
{
    public partial class ChatViewModel : BaseViewModel
    {
        private readonly IOpenAIService _openAIService;

        [ObservableProperty]
        private bool isPopupVisible;

        [ObservableProperty]
        private ObservableCollection<Message> content = new ObservableCollection<Message>();



        [ObservableProperty]
        public string currentMessage;

        public ChatViewModel(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
            content = new ObservableCollection<Message>();

        }


        [RelayCommand]
        private void ShowChat()
        {
            IsPopupVisible = true;
        }

        [RelayCommand]
        private void CloseChat()
        {
            IsPopupVisible = false;
        }



        [RelayCommand]
        public async Task SendMessage()
        {
            if (!string.IsNullOrEmpty(CurrentMessage))
            {
                Content.Add(new Message { Content = "You: \n" + CurrentMessage, IsUserMessage = true, IsTextActive = true });
                var response = await _openAIService.AskQuestion(CurrentMessage);
                Content.Add(new Message { Content = "DyslexiaAI: \n" + response, IsUserMessage = false, IsTextActive = true });
                CurrentMessage = string.Empty;
            }
        }
    }
}