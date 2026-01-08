using Microsoft.AspNetCore.Http;

public interface IImageService
{
    Task<string> UploadAsync(IFormFile file);
}