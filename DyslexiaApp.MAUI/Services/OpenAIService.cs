using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using DyslexiaApp.MAUI.Helpers;
using DyslexiaApp.MAUI.Models;

namespace DyslexiaApp.MAUI.Services
{
    // This class implements the IOpenAIService interface
    public class OpenAIService : IOpenAIService
    {
        HttpClient client; // HttpClient instance to send HTTP requests
        JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true }; // Options for JSON serialization

        // Constructor to initialize the HttpClient and set default headers
        public OpenAIService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Constants.OpenAIUrl); // Set the base URL for the OpenAI API
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.OpenAIToken); // Set the authorization header with the OpenAI API token
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // Set the Accept header to JSON
        }

        // Method to send a query to the OpenAI API and get a response
        public async Task<string> AskQuestion(string query)
        {
            // Create a completion request object with the query
            var completion = new CompletionRequest()
            {
                Prompt = query
            };

            // Serialize the completion request object to JSON
            var body = JsonSerializer.Serialize(completion);
            // Create an HTTP content object with the serialized JSON
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            // Send a POST request to the OpenAI completions endpoint with the JSON content
            var response = await client.PostAsync(Constants.OpenAIEndpoint_Completions, content);

            // Check if the response is successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a CompletionResponse object
                var data = await response.Content.ReadFromJsonAsync<CompletionRespsonse>(options);
                // Return the first choice's text from the response
                return data?.Choices?.FirstOrDefault().Text;
            }


            return default;
        }
    }
}