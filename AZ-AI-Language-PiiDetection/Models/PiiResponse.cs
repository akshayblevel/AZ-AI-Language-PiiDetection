namespace AZ_AI_Language_PiiDetection.Models
{
    public class PiiResponse
    {
        public string RedactedText { get; set; } = string.Empty;
        public List<PiiEntity> Entities { get; set; } = new();
    }
}
