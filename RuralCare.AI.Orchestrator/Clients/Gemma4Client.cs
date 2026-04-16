using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RuralCare.AI.Orchestrator.Clients
{
    public class Gemma4Client
    {
        private readonly HttpClient _httpClient;

        public Gemma4Client(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GenerateClinicalSummaryAsync(string prompt)
        {
            var request = new
            {
                model = "gemma4:e4b",
                prompt = prompt,
                stream = false
            };

            var response = await _httpClient.PostAsJsonAsync(
                "http://localhost:11434/api/generate",
                request);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadFromJsonAsync<JsonElement>();

            return json.GetProperty("response").GetString() ?? string.Empty;
        }
    }
}