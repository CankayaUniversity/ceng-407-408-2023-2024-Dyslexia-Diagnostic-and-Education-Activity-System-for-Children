using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.ViewModels
{
    public partial class ChatViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool isPopupVisible;

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

        [ObservableProperty]
        private ObservableCollection<string> messages;

        [ObservableProperty]
        private string currentMessage;

        public ChatViewModel()
        {
            Messages = new ObservableCollection<string>();
        }

        [RelayCommand]
        public void SendMessage()
        {
            if (!string.IsNullOrEmpty(CurrentMessage))
            {
                Messages.Add(CurrentMessage);
                CurrentMessage = string.Empty; // Mesaj gönderildikten sonra girişi temizle
            }
        }
    }
}