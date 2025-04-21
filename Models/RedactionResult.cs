namespace PHI.Models
{
    public class RedactionResult
    {
        public string? OriginalFileName { get; set; }
        public string? RedactedContent { get; set; }
        public List<string>? RedactedItems { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public byte[]? FileBytes { get; set; }  
        public string? ContentType { get; set; } 
    }
}
