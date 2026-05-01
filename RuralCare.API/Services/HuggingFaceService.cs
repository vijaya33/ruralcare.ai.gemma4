namespace RuralCare.API.Services
{
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;

    namespace RuralCare.API.Services
    {
        public class HuggingFaceService
        {
            private readonly HttpClient _httpClient;
            private readonly IConfiguration _configuration;

            public HuggingFaceService(HttpClient httpClient, IConfiguration configuration)
            {
                _httpClient = httpClient;
                _configuration = configuration;
            }

            public async Task<string> GetAIResponse(string prompt)
            {
                /* Commenting as a security feature, GitHub does not push code to public repository with a secret code in the files. */
                /*
                var apiKey = _configuration["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"];  // Hugging Face API Key. 
                var modelName = _configuration["google/gemma-4-E2B-it"];  // Hugging Face Gemma 4 model name.
                */
                var apiKey = "UN_COMMENT_ABOVE_CODE";
                var modelName = "UN_COMMENT_MODEL_NAME_ABOVE"; 

                var request = new HttpRequestMessage(
                    HttpMethod.Post,
                    $"https://api-inference.huggingface.co/models/{modelName}"  /* new code addition */
                );

                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", apiKey);

                var payload = new
                {
                    inputs = prompt,
                    parameters = new
                    {
                        max_new_tokens = 300,
                        temperature = 0.4,
                        return_full_text = false
                    }
                };

                request.Content = new StringContent(
                    JsonSerializer.Serialize(payload),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await _httpClient.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Hugging Face error: {response.StatusCode} - {result}");
                }

                return result;
            }
        }
    }
}