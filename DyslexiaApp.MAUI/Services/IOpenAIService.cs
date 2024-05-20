using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.Services
{
    public interface IOpenAIService
    {
        Task<string> AskQuestion(string query);

    }
}