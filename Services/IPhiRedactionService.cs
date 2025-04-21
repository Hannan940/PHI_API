using PHI.Helper;
using PHI.Models;

namespace PHI.Services
{
    public interface IPhiRedactionService
    {
        Task<ServiceResponse<RedactionResult>> RedactPhi(IFormFile file);
    }
}
