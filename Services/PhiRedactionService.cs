using PHI.Models;
using PHI.Services;
using System.Text;
using PHI.Constants;
using PHI.Helper;
using Microsoft.Extensions.Options;

public class PhiRedactionService : IPhiRedactionService
{
    private readonly ILogger<PhiRedactionService> _logger;
    private readonly PHIConfig _phiConfig;

    public PhiRedactionService(ILogger<PhiRedactionService> logger, IOptions<PHIConfig> phiConfig)
    {
        _phiConfig = phiConfig.Value;
        _logger = logger;
    }

    /// <summary>
    /// Main method that Redacts protected health information (PHI) from the provided file.
    /// </summary>
    /// <param name="file">The uploaded file (only .txt supported).</param>
    /// <returns></returns>
    public async Task<ServiceResponse<RedactionResult>> RedactPhi(IFormFile file)
    {
        //Read File from the request
        var fileInfo = await FileIO.ReadFileAsync(file, _phiConfig.ValidFormats);

        var result = new RedactionResult
        {
            OriginalFileName = fileInfo.FileName,
            RedactedItems = new List<string>()
        };

        try
        {
            if (string.IsNullOrWhiteSpace(fileInfo.Content))
            {
                _logger.LogWarning("File content is empty. File: {FileName}", fileInfo.FileName);
                return ServiceResponse<RedactionResult>.ReturnFailed(400, ErrorMessages.NoFileContent);

            }
            _logger.LogInformation("Started processing file: {FileName}", fileInfo.FileName);

            // Save sthe original file to the Requests Folder
            string originalFilePath = await FileIO.WriteFileAsync($"{fileInfo.FileName}_{DateTime.Now:yyyyMMdd_HHmmss}_sanitized.txt", Encoding.UTF8.GetBytes(fileInfo.Content), _phiConfig.RequestsDirectoryPath);
            _logger.LogInformation("Original file saved to: {FilePath}", originalFilePath);

            // List all redaction patterns available 
            var allPatterns = PhiPatterns.PersonalIdentificationPatterns
                .Concat(PhiPatterns.ContactInformationPatterns)
                .Concat(PhiPatterns.HealthInformationPatterns)
                .Concat(PhiPatterns.LocationInformationPatterns)
                .ToList();

            // Perform redaction
            var (redactedContent, redactedItems) = PhiHelper.PerformRedaction(fileInfo.Content, allPatterns);

            result.RedactedContent = redactedContent;
            result.RedactedItems = redactedItems;
            result.Success = true;
            result.FileBytes = Encoding.UTF8.GetBytes(redactedContent);

            //Save sthe redacted (sanitized) content to the Processed directory
            string sanitizedFilePath = await FileIO.WriteFileAsync(
               $"{Path.GetFileNameWithoutExtension(fileInfo.FileName)}_{DateTime.Now:yyyyMMdd_HHmmss}.txt",
               result.FileBytes,
               _phiConfig.SanitizedDirectoryPath
           );
            _logger.LogInformation("Sanitized file saved to: {FilePath}", sanitizedFilePath);
            return ServiceResponse<RedactionResult>.ReturnResultWith200(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while processing file: {FileName}", file?.FileName);
            result.Success = false;
            result.ErrorMessage = ex.Message;
            return ServiceResponse<RedactionResult>.Return500();
        }
    }
}
