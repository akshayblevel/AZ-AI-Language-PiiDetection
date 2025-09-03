namespace AZ_AI_Language_PiiDetection.Models
{
    public class PiiRequest
    {
        public string Text { get; set; } = string.Empty;
        public string Language { get; set; } = "en";
    }
}
