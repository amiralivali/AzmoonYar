namespace AzmoonYar.Infrastructure.Exceptions;

public class DeletePhotoException(Exception? inner = null)
    : Exception("حذف تصویر با خطا مواجه شد.", inner);