namespace AzmoonYar.Infrastructure.Exceptions;

public class UploadPhotoException(Exception? inner = null)
    : Exception("آپلود تصویر با خطا مواجه شد.", inner);

