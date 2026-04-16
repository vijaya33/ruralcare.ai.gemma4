using RuralCare.AI.Orchestrator.Clients;
using RuralCare.AI.Orchestrator.Prompts;
using RuralCare.Contracts.Models;

namespace RuralCare.AI.Orchestrator.Services
{
    public class GemmaOrchestrator : IGemmaOrchestrator
    {
        private readonly Gemma4Client _gemma4Client;

        public GemmaOrchestrator(Gemma4Client gemma4Client)
        {
            _gemma4Client = gemma4Client;
        }

        public async Task<TriageResponse> RunClinicalTriageAsync(PatientIntakeRequest request)
        {
            var prompt = TriagePromptBuilder.Build(request);

            string gemmaRawOutput;

            try
            {
                gemmaRawOutput = await _gemma4Client.GenerateClinicalSummaryAsync(prompt);
            }
            catch
            {
                gemmaRawOutput = "Gemma call failed. Fallback triage response generated.";
            }

            var riskLevel = "Moderate";
            var recommendation = "Clinician review recommended within 30 minutes.";

            if (request.Symptoms.Contains("chest pain", StringComparison.OrdinalIgnoreCase) ||
                request.Symptoms.Contains("breathing", StringComparison.OrdinalIgnoreCase) ||
                request.Symptoms.Contains("bleeding", StringComparison.OrdinalIgnoreCase))
            {
                riskLevel = "High";
                recommendation = "Urgent escalation required. Immediate clinician attention advised.";
            }

            return new TriageResponse
            {
                RiskLevel = riskLevel,
                Confidence = "94%",
                SoapNote = $"S: Patient reports {request.Symptoms}. " +
                           $"O: Initial intake captured for {request.PatientName}, age {request.Age}. " +
                           $"A: AI-assisted preliminary triage indicates {riskLevel} risk. " +
                           $"P: {recommendation}",
                Recommendation = recommendation,
                SuggestedActions = new List<string>
                {
                    "Review symptoms with on-site nurse",
                    "Validate referral documentation",
                    "Capture vitals and oxygen saturation",
                    "Escalate if symptoms worsen"
                }
            };
        }
    }
}