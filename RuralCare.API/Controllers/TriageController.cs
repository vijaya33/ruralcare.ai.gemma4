using Microsoft.AspNetCore.Mvc;
using RuralCare.API.Services;
using RuralCare.API.Services.RuralCare.API.Services;
using RuralCare.Contracts.Models;

   namespace RuralCare.API.Controllers
    {
        [ApiController]
        [Route("api/triage")]
        public class TriageController : ControllerBase
        {
            private readonly HuggingFaceService _huggingFaceService;

            public TriageController(HuggingFaceService huggingFaceService)
            {
                _huggingFaceService = huggingFaceService;
            }

            [HttpPost("analyze")]
        public async Task<ActionResult<TriageResponse>> Analyze([FromBody] PatientTriageRequest request)
            //public async Task<IActionResult> Analyze([FromBody] PatientTriageRequest request)
            {
                var prompt = $@"
                        You are an AI medical triage assistant.

                        Patient Information:
                        Name: {request.PatientName}
                        Age: {request.Age}
                        Symptoms: {request.Symptoms}
                        Duration: {request.Duration}
                        Medical History: {request.MedicalHistory}

                        Return the triage result in this format:

                        Severity Level:
                        Possible Conditions:
                        Recommended Next Steps:
                        Emergency Warning Signs:
                        ";

                var result = await _huggingFaceService.GetAIResponse(prompt);

                return Ok(new
                {
                    model = "google/gemma-4-E2B-it",
                    triageResult = result
                });
            }
        }

        public class PatientTriageRequest
        {
            public string? PatientName { get; set; }
            public int Age { get; set; }
            public string? Symptoms { get; set; }
            public string? Duration { get; set; }
            public string? MedicalHistory { get; set; }
        }
    }
