using PHI.Models;

namespace PHI.Constants
{

    public static class PhiPatterns
    {
        // Personal Identification Patterns
        public static List<PhiPattern> PersonalIdentificationPatterns = new List<PhiPattern>
    {
        new PhiPattern(@"\b\d{3}-\d{2}-\d{4}\b", "SSN"),
        new PhiPattern(@"Social Security Number:\s*([^\n]+)", "SSN"),
        new PhiPattern(@"\bMRN-\d+\b", "Medical Record Number"),
        new PhiPattern(@"Medical Record Number:\s*([^\n]+)", "Medical Record Number")
    };

        // Contact Information Patterns
        public static List<PhiPattern> ContactInformationPatterns = new List<PhiPattern>
    {
        new PhiPattern(@"Phone Number:\s*([^\n]+)", "Phone Number"),
        new PhiPattern(@"\b\(\d{3}\) \d{3}-\d{4}\b", "Phone Number"),
        new PhiPattern(@"\b\d{3}-\d{3}-\d{4}\b", "Phone Number"),
        new PhiPattern(@"\b\d{3}\.\d{3}\.\d{4}\b", "Phone Number"),
        new PhiPattern(@"\b\d{3}\s\d{3}\s\d{4}\b", "Phone Number"),
        new PhiPattern(@"\b\d{10}\b", "Phone Number"),
        new PhiPattern(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b", "Email")
    };

        // Health Information Patterns
        public static List<PhiPattern> HealthInformationPatterns = new List<PhiPattern>
    {
        new PhiPattern(@"Patient Name:\s*([^\n]+)", "Patient Name"),
        new PhiPattern(@"Date of Birth:\s*(\d{1,2}/\d{1,2}/\d{2,4})", "Date of Birth"),
        new PhiPattern(@"DOB:\s*(\d{1,2}/\d{1,2}/\d{2,4})", "Date of Birth")
    };

        // Location Information Patterns
        public static List<PhiPattern> LocationInformationPatterns = new List<PhiPattern>
    {
        new PhiPattern(@"Address:\s*([^\n]+)", "Address"),
        new PhiPattern(@"\b\d+\s+([A-Za-z]+\s*)+,\s*[A-Za-z]+\s*,\s*[A-Za-z]+\b", "Address")
    };
    }

}
