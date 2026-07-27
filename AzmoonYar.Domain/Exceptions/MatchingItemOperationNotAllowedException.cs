namespace AzmoonYar.Domain.Exceptions;

public class MatchingItemOperationNotAllowedException():
    Exception("Matching item operations are only allowed for Matching questions.")
{
    
}