using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace RealEstateCam.Infrastructure.Storage
{
    public class FileSystemStorage : IFileStorage
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWebHostEnvironment _env;

        public FileSystemStorage(IHttpContextAccessor contextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _contextAccessor = contextAccessor;
            _env = webHostEnvironment;
        }

        public async Task<string> SaveFileAsync(IFormFile file, string folder)
        {
            var uploadsFolder = Path.Combine(_env.WebRootPath, folder);

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var request = _contextAccessor.HttpContext!.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";

            return $"{baseUrl}/{folder}/{uniqueFileName}";
        }
    }
}
