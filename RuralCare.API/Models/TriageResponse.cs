namespace RuralCare.API.Models
{

    public class TriageResponse
    {
        public string SoapNote { get; set; } = string.Empty;
        public string RiskLevel { get; set; } = "Low";
        public string Recommendation { get; set; } = string.Empty;
        public double ConfidenceScore { get; set; }
    }
}