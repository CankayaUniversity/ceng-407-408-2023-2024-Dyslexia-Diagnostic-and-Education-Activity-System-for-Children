using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.Models
{
    // This class represents a request to the OpenAI API for text completion
    public class CompletionRequest
    {
        // The model to use for the completion request (default is "gpt-3.5-turbo-instruct")
        [JsonPropertyName("model")]
        public string Model { get; set; } = "gpt-3.5-turbo-instruct";

        // The prompt or input text for the completion request
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        // The temperature setting for the completion request, controls the randomness of the output (default is 0)
        [JsonPropertyName("temperature")]
        public double Temperature { get; set; } = 0;

    }
}