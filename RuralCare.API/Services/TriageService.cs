using RuralCare.AI.Orchestrator.Services;
using RuralCare.Contracts.Models;

namespace RuralCare.API.Services
{
    public interface ITriageService
    {
        Task<TriageResponse> AnalyzeAsync(PatientIntakeRequest request);
    }

    public class TriageService : ITriageService
    {
        private readonly IGemmaOrchestrator _gemmaOrchestrator;

        public TriageService(IGemmaOrchestrator gemmaOrchestrator)
        {
            _gemmaOrchestrator = gemmaOrchestrator;
        }

        public async Task<TriageResponse> AnalyzeAsync(PatientIntakeRequest request)
        {
            return await _gemmaOrchestrator.RunClinicalTriageAsync(request);
        }
    }
}