namespace AzmoonYar.Domain.Exceptions;

public class OptionalItemOperationNotAllowedException():
    Exception("Option operations are only allowed for Multiple Choice questions.")
{
    
}