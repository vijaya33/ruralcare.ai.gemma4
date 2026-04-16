using RuralCare.Contracts.Models;

namespace RuralCare.AI.Orchestrator.Services
{
    public interface IGemmaOrchestrator
    {
        Task<TriageResponse> RunClinicalTriageAsync(PatientIntakeRequest request);
    }
}