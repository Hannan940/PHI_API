namespace PHI.Models
{
    public class PhiPattern
    {
        public string Pattern { get; set; }
        public string Category { get; set; }

        public PhiPattern(string pattern, string category)
        {
            Pattern = pattern;
            Category = category;
        }
    }

}
