using Microsoft.AspNetCore.Mvc;
using PHI.Controllers;
using PHI.Services;

namespace LabOrderRedaction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PHIController : BaseController
    {
        private readonly IPhiRedactionService _redactionService;
        //string[] _validFormats = { ".txt" };

        public PHIController(IPhiRedactionService redactionService)
        {
            _redactionService = redactionService;
        }


        /// <summary>
        /// Endpoint to redact protected health information (PHI) from a file.
        /// </summary>
        /// <param name="file">Input file</param>
        /// <returns>Standard Service Response Object that will return success or failure. </returns>
        [HttpPost("redact-file")]
        public async Task<IActionResult> RedactFile(IFormFile file)
        {
            var result = await _redactionService.RedactPhi(file);
            return ReturnFormattedResponse(result);
        }
    }
}
