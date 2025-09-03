using AZ_AI_Language_PiiDetection.Models;

namespace AZ_AI_Language_PiiDetection.Interfaces
{
    public interface IAnalysisService
    {
        Task<PiiResponse> PiiDetectionAnalysis(PiiRequest piiRequest);
    }
}
