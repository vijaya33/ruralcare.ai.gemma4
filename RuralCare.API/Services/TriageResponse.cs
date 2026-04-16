using RuralCare.API.Services;
using RuralCare.API.Models;

namespace RuralCare.API.Services
{

    public interface ITriageService
    {
        Task<TriageResponse> AnalyzeAsync(PatientIntakeRequest request);
    }

    public class TriageService : ITriageService
    {
        private readonly IGemmaOrchestrator _gemma;

        public TriageService(IGemmaOrchestrator gemma)
        {
            _gemma = gemma;
        }

        public async Task<TriageResponse> AnalyzeAsync(PatientIntakeRequest request)
        {
            return await _gemma.RunClinicalTriageAsync(request);
        }
    }
}