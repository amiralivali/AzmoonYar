namespace AzmoonYar.Application.Interfaces;

public interface IFileStorageService
{
    Task<string> UploadAsync(Stream fileStream, string fileName, string contentType, CancellationToken ct = default);
    Task DeleteAsync(string fileKey, CancellationToken ct = default);
    string GetFileUrl(string fileKey);
}