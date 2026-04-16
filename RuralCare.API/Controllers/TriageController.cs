using Microsoft.AspNetCore.Mvc;
using RuralCare.API.Models;
using RuralCare.API.Services;

namespace RuralCare.API.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class TriageController : ControllerBase
        {
            private readonly ITriageService _triageService;

          
            public TriageController(ITriageService triageService)
            {
                _triageService = triageService;
            }

            [HttpPost("analyze")]
            public async Task<IActionResult> Analyze([FromBody] PatientIntakeRequest request)
            {
                var result = await _triageService.AnalyzeAsync(request);
                return Ok(result);
            }
        }
    }
