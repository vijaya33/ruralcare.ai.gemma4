namespace RuralCare.API.Models
{

    public class PatientIntakeRequest
    {
        public string PatientName { get; set; } = string.Empty;
        public string Symptoms { get; set; } = string.Empty;
        public string Language { get; set; } = "en";
        public string? ImageUrl { get; set; }
    }
}
