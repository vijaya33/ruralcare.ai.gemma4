using System.ComponentModel.DataAnnotations;

namespace RuralCare.Web.Models
{

    public class PatientIntakeModel
    {
        [Required]
        [StringLength(100)]
        public string PatientName { get; set; } = string.Empty;

        [Range(0, 120)]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required]
        public string PreferredLanguage { get; set; } = "English";

        [Required]
        [StringLength(1000, MinimumLength = 5)]
        public string Symptoms { get; set; } = string.Empty;

        public string VillageOrLocation { get; set; } = string.Empty;

        public bool HasReferralDocument { get; set; }

        public bool HasWoundImage { get; set; }
    }
}