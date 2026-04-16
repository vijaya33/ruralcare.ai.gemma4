using RuralCare.AI.Orchestrator.Clients;
using RuralCare.AI.Orchestrator.Prompts;
using RuralCare.Web.Models;

namespace RuralCare.AI.Orchestrator
{
    public class GemmaOrchestrator
    {
        private readonly Gemma4Client _client;

        public GemmaOrchestrator(Gemma4Client client)
        {
            _client = client;
        }

        public async Task<string> RunClinicalTriageAsync(PatientIntakeModel request)
        {
            var prompt = TriagePromptBuilder.Build(request);
            return await _client.GenerateClinicalSummaryAsync(prompt);
        }
    }
}