namespace AzmoonYar.Infrastructure.Storage.Arvan;

public class ArvanStorageOptions
{
    public const string SectionName = "ArvanStorage";

    public string AccessKey { get; set; } = null!;
    public string SecretKey { get; set; } = null!;
    public string ServiceUrl { get; set; } = null!;
    public string BucketName { get; set; } = null!;
    public string AuthenticationRegion { get; set; } = null!;
}