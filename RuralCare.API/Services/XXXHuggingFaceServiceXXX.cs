using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace RuralCare.API.Services
{

    public class XXXHuggingFaceServiceXXX
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiKey = "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";
        // Rwad only access token for 
        static string Gemma4ReadOnlyAccessTokenOnHuggingFace = "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";
        static string Gemma4ModelUrl = "https://huggingface.co/google/gemma-4-E2B-it";

        public XXXHuggingFaceServiceXXX(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAIResponse(string prompt)
        {
            var request = new HttpRequestMessage(
                HttpMethod.Post,
           "https://api-inference.huggingface.co/models/google/gemma-4-E2B-it"

            );

            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", _apiKey);

            var payload = new
            {
                inputs = prompt,
                parameters = new
                {
                    max_new_tokens = 200,
                    temperature = 0.7
                }
            };

            request.Content = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
