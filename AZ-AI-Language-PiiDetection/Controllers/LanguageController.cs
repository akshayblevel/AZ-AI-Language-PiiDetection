using AZ_AI_Language_PiiDetection.Interfaces;
using AZ_AI_Language_PiiDetection.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AZ_AI_Language_PiiDetection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController(IAnalysisService analysisService) : ControllerBase
    {
        [HttpPost("PiiDetection")]
        public async Task<IActionResult> SentimentAnalysis([FromBody] PiiRequest piiRequest)
        {
            var result = await analysisService.PiiDetectionAnalysis(piiRequest);
            return Ok(result);
        }
    }
}
