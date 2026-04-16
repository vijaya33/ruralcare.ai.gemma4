namespace RuralCare.Contracts.Models
{

    public class PatientIntakeRequest
    {
        public string PatientName { get; set; } = string.Empty;
        public string Symptoms { get; set; } = string.Empty;
        public string Language { get; set; } = "en";
        public string? ImageUrl { get; set; }
        public int Age { get; set; }
        public string PreferredLanguage { get; set; } = "English";
        public string VillageOrLocation { get; set; } = string.Empty;

    }
}
