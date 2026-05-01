

using System.Net.Http.Json;

namespace RuralCare.AI.Orchestrator.Clients;

public class Gemma4Client
{
    private readonly HttpClient _httpClient;
    string Gemma4ReadOnlyAccessTokenOnHuggingFace = "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"; 

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

        var json = await response.Content.ReadAsStringAsync();
        return json;
    }
}