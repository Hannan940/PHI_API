namespace PHI.Models
{
    public class PhiPatternModel
    {
        public string Pattern { get; set; }
        public string Category { get; set; }

        public PhiPatternModel(string pattern, string category)
        {
            Pattern = pattern;
            Category = category;
        }
    }

}
