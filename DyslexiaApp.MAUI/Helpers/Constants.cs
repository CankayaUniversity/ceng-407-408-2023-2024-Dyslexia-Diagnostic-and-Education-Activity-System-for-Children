using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.Helpers
{
    // This static class contains constant values used throughout the application
    public static class Constants
    {
        // Base URL for the OpenAI API
        public const string OpenAIUrl = "https://api.openai.com/";

        // API token for authenticating with the OpenAI service
        public const string OpenAIToken = "";

        // Endpoint for the OpenAI completions API
        public const string OpenAIEndpoint_Completions = "v1/completions";
    }
}