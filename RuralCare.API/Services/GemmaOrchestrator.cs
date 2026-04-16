using RuralCare.API.Models;

namespace RuralCare.API.Services
{

    public interface IGemmaOrchestrator
    {
        Task<TriageResponse> RunClinicalTriageAsync(PatientIntakeRequest request);
    }

    public class GemmaOrchestrator : IGemmaOrchestrator
    {
        public Task<TriageResponse> RunClinicalTriageAsync(PatientIntakeRequest request)
        {
            var response = new TriageResponse
            {
                SoapNote = $"Patient reports: {request.Symptoms}",
                RiskLevel = "Moderate",
                Recommendation = "Escalate to clinician review within 30 minutes.",
                ConfidenceScore = 0.94
            };

            return Task.FromResult(response);
        }
    }
}
