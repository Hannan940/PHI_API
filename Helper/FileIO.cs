using PHI.Models;

namespace PHI.Helper
{
    /// <summary>
    /// Helper class for file operations.
    /// </summary>
    public class FileIO
    {

        /// <summary>
        /// Reads a file and returns its content as a string.
        /// </summary>
        /// <param name="file">The uploaded IFormFile.</param>
        /// /// <param name="validFormats">optional array of allowed file extensions</param>
        /// <returns>A FileDataModel containing file name and content</returns>
        public static async Task<FileDataModel> ReadFileAsync(IFormFile file, string[] validFormats = null)
        {
            
            if (validFormats != null && validFormats.Any())
            {
                var fileExtension = Path.GetExtension(file.FileName).ToLower();

                if (!validFormats.Contains(fileExtension))
                {
                    throw new Exception($"Invalid file format. Accepted formats are: {string.Join(", ", validFormats)}");
                }
            }

            FileDataModel fileObject = new FileDataModel();
            try
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    string content = await reader.ReadToEndAsync();
                    fileObject.FileName = file.FileName;
                    fileObject.Content = content;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Reading File. Message:" + ex.Message);
            }
            return fileObject;
        }

        /// <summary>
        /// Writes a byte array to a file asynchronously.
        /// </summary>
        /// <param name="fileName">The name of the file to create.</param>
        /// <param name="contentBytes">The byte array containing file content.</param>
        /// <param name="directoryPath"></param>
        /// <returns>The full path of the written file.</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<string> WriteFileAsync(string fileName, byte[] contentBytes, string directoryPath = "wwwroot/Files")
        {
            try
            {
                Directory.CreateDirectory(directoryPath);

                var filePath = Path.Combine(directoryPath, fileName);

                await File.WriteAllBytesAsync(filePath, contentBytes);

                return filePath;
            }
            catch (Exception ex)
            {
                throw new Exception("Error writing file. Message: " + ex.Message);
            }
        }
    }
}
