namespace AzmoonYar.Domain.Exceptions;

public class FillInBlankItemOperationNotAllowedException()
    : Exception("FillInBlank item operations are only allowed for Fill-in-the-blank questions.")
{
    
}