namespace AZ_AI_Language_PiiDetection.Models
{
    public class PiiEntity
    {
        public string Text { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public double ConfidenceScore { get; set; }
        public int Offset { get; set; }
        public int Length { get; set; }
    }
}
