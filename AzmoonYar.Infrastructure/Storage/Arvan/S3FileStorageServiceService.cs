using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using AzmoonYar.Application.Interfaces;
using AzmoonYar.Infrastructure.Exceptions;
using Microsoft.Extensions.Options;

namespace AzmoonYar.Infrastructure.Storage.Arvan;

public class S3FileStorageServiceService(IAmazonS3 s3Client, IOptions<ArvanStorageOptions> options)
    : IFileStorageService
{
    private readonly ArvanStorageOptions _options = options.Value;

    public async Task<string> UploadAsync(Stream fileStream, string fileName, string contentType, CancellationToken ct = default)
    {
        var key = $"{Guid.NewGuid()}-{fileName}";

        var request = new PutObjectRequest
        {
            BucketName = _options.BucketName,
            Key = key,
            InputStream = fileStream,
            ContentType = contentType,
            CannedACL = S3CannedACL.PublicRead
        };

        try
        {
            await s3Client.PutObjectAsync(request, ct);
        }
        catch (Exception ex) when (ex is AmazonS3Exception or AmazonServiceException or AmazonClientException)
        {
            throw new UploadPhotoException(ex);
        }

        return key;
    }

    public async Task DeleteAsync(string fileKey, CancellationToken ct = default)
    {
        var request = new DeleteObjectRequest
        {
            BucketName = _options.BucketName,
            Key = fileKey
        };

        try
        {
            await s3Client.DeleteObjectAsync(request, ct);
        }
        catch (Exception ex) when (ex is AmazonS3Exception or AmazonServiceException or AmazonClientException)
        {
            throw new DeletePhotoException(ex);
        }
    }

    public string GetFileUrl(string fileKey)
    {
        return $"https://{_options.BucketName}.{_options.ServiceUrl.Replace("https://", "")}/{fileKey}";
    }
}