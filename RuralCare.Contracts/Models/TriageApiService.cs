
using System.Net.Http.Json;
using RuralCare.Web.Models;
using RuralCare.Contracts.Models;

namespace RuralCare.Web.Services
{
    public class TriageApiService
    {
        private readonly HttpClient _httpClient;

        public TriageApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TriageResultModel> AnalyzeAsync(PatientIntakeModel model)
        {

            var response = await _httpClient.PostAsJsonAsync("api/Triage/analyze", model);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();

                throw new ApplicationException(
                    $"Triage API call failed. Status: {(int)response.StatusCode}, Details: {error}");
            }

            var result = await response.Content.ReadFromJsonAsync<TriageResultModel>();

            if (result is null)
            {
                throw new ApplicationException("Triage API returned an empty response.");
            }

            return result;
        }        
    }
}