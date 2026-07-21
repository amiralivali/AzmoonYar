namespace AzmoonYar.Domain.Exceptions;

public class InvalidLessonCountException():Exception("Invalid lesson count. lesson count must be grater than zero and smaller than 30");