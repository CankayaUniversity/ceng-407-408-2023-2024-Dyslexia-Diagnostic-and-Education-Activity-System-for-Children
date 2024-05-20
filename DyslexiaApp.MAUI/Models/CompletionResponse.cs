using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.Models
{
    public class CompletionRespsonse
    {
        public string Id { get; set; }
        public List<Choice> Choices { get; set; }
    }
}