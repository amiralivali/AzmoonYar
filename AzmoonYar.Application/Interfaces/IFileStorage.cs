namespace AzmoonYar.Application.Interfaces;

public interface IFileStorage
{
    Task<string> SaveImageAsync(Stream stream, string fileName, string folderName);
    Task DeleteAsync(string filePath);
}