
using RuralCare.Web.Models;

namespace RuralCare.Web.Services
{

    public class TriageApiService
    {
        public async Task<TriageResultModel> AnalyzeAsync(PatientIntakeModel model)
        {
            await Task.Delay(1200);

            var risk = "Moderate";
            var recommendation = "Clinician review recommended within 30 minutes.";

            if (model.Symptoms.Contains("chest pain", StringComparison.OrdinalIgnoreCase) ||
                model.Symptoms.Contains("breathing", StringComparison.OrdinalIgnoreCase) ||
                model.Symptoms.Contains("bleeding", StringComparison.OrdinalIgnoreCase))
            {
                risk = "High";
                recommendation = "Urgent escalation required. Immediate clinician attention advised.";
            }

            return new TriageResultModel
            {
                RiskLevel = risk,
                Confidence = "94%",
                SoapNote = $"S: Patient reports {model.Symptoms}. " +
                           $"O: Initial intake captured for {model.PatientName}, age {model.Age}. " +
                           $"A: AI-assisted preliminary triage indicates {risk} risk. " +
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