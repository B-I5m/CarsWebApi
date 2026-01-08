using Microsoft.AspNetCore.Http;

public class ImageService : IImageService
{
    private readonly string _path = "wwwroot/images";

    public async Task<string> UploadAsync(IFormFile file)
    {
        Directory.CreateDirectory(_path);

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var fullPath = Path.Combine(_path, fileName);

        using var stream = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(stream);

        return $"/images/{fileName}";
    }
}