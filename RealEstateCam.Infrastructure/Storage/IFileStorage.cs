using Microsoft.AspNetCore.Http;

namespace RealEstateCam.Infrastructure.Storage
{
    public interface IFileStorage
    {
        Task<string> SaveFileAsync(IFormFile file, string folder);
    }
}
