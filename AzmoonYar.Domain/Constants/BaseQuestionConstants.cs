namespace AzmoonYar.Domain.Constants;

public static class BaseQuestionConstants
{
    public const int QuestionTextMaxLength = 200;
    public const int PictureMaxLenght = 1000;
    public const long MaxPictureFileSizeInBytes = 2 * 1024 * 1024;
    public static readonly string[] AllowedPictureExtensions = [".jpg", ".jpeg", ".png", ".webp"];
}