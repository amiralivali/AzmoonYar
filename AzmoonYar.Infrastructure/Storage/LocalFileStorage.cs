using AzmoonYar.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace AzmoonYar.Infrastructure.Storage;

public class LocalFileStorage(IWebHostEnvironment environment) : IFileStorage
{
    public async Task<string> SaveImageAsync(
        Stream stream,
        string fileName,
        string folder)
    {
        var uploadPath = Path.Combine(
            environment.WebRootPath,
            "Uploads",
            folder);
        Directory.CreateDirectory(uploadPath);
        var filePath = Path.Combine(uploadPath, fileName);
        await using var fileStream = new FileStream(
            filePath,
            FileMode.Create);
        await stream.CopyToAsync(fileStream);
        return $"/Uploads/{folder}/{fileName}";
    }

    public Task DeleteAsync(string filePath)
    {
        var fullPath = Path.Combine(
            environment.WebRootPath,
            filePath.TrimStart('/'));
        if (File.Exists(fullPath))
            File.Delete(fullPath);
        return Task.CompletedTask;
    }
}