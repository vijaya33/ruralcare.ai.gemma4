

namespace RuralCare.Contracts.Models
{
    public class TriageResponse
    {
        public string RiskLevel { get; set; } = string.Empty;
        public string Confidence { get; set; } = string.Empty;
        public string SoapNote { get; set; } = string.Empty;
        public string Recommendation { get; set; } = string.Empty;

        public string ConfidenceScore { get; set; } = string.Empty;

        public List<string> SuggestedActions { get; set; } = new();
    }
}