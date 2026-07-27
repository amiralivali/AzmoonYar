namespace AzmoonYar.Domain.Exceptions;

public class TrueFalseItemOperationNotAllowedException():
    Exception("True/False item operations are only allowed for True/False questions.")
{
    
}