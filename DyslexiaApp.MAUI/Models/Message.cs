using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.Models
{
    public class Message
    {
        public string? Content { get; set; }
        public bool IsUserMessage { get; set; }
        public bool IsTextActive { get; set; }
    }
}