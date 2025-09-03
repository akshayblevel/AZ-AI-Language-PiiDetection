using AZ_AI_Language_PiiDetection.Interfaces;
using AZ_AI_Language_PiiDetection.Models;
using Azure.AI.TextAnalytics;
using Azure.Core;

namespace AZ_AI_Language_PiiDetection.Services
{
    public class AnalysisService(TextAnalyticsClient textAnalytics) : IAnalysisService
    {
        public async Task<PiiResponse> PiiDetectionAnalysis(PiiRequest piiRequest)
        {
            var response = await textAnalytics.RecognizePiiEntitiesAsync(piiRequest.Text, piiRequest.Language);

            var piiEntities = new List<Models.PiiEntity>();
            foreach (var entity in response.Value)
            {
                piiEntities.Add(new Models.PiiEntity
                {
                    Text = entity.Text,
                    Category = entity.Category.ToString(),
                    ConfidenceScore = entity.ConfidenceScore,
                    Offset = entity.Offset,
                    Length = entity.Length
                });
            }

            return new PiiResponse
            {
                RedactedText = response.Value.RedactedText,
                Entities = piiEntities
            };
        }
    }
}
