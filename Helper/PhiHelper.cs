using PHI.Models;
using System.Text.RegularExpressions;

namespace PHI.Helper
{
    public static class PhiHelper
    {
        /// <summary>
        /// Performs PHI redaction on the provided content using the given PHI patterns.
        /// </summary>
        /// <param name="content">The original string content that may contain sensitive information.</param>
        /// <param name="phiPatterns">A list of PhiPattern objects, each containing a regex pattern and a category label.</param>
        /// <returns>
        /// A tuple containing:
        /// 1. The redacted version of the content.
        /// 2. A list of redacted items (with category labels) for auditing or review.
        /// </returns>
        public static (string redactedContent, List<string> redactedItems) PerformRedaction(string content, List<PhiPattern> phiPatterns)
        {
            var redactedContent = content;
            var redactedItems = new List<string>();


            foreach (var pattern in phiPatterns)
            {
                // Use Regex to find all matches for the current pattern
                var matches = Regex.Matches(redactedContent, pattern.Pattern, RegexOptions.IgnoreCase);
                foreach (Match match in matches)
                {
                    if (match.Groups.Count > 1)
                    {
                        redactedItems.Add($"{pattern.Category}: {match.Groups[1].Value}");
                        redactedContent = redactedContent.Replace(match.Groups[1].Value, "**********");
                    }
                    else
                    {
                        redactedItems.Add($"{pattern.Category}: {match.Value}");
                        redactedContent = redactedContent.Replace(match.Value, "**********");
                    }
                }
            }

            return (redactedContent, redactedItems.Distinct().ToList());
        }
    }
}
