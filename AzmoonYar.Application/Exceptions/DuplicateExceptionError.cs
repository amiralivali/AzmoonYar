namespace AzmoonYar.Application.Exceptions;

public class DuplicateExceptionError(string entity) : Exception($"{entity} has  already been added to the database.");