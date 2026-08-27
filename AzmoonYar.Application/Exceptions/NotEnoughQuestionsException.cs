using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Application.Exceptions;

public class NotEnoughQuestionsException(QuestionType questionType, int questionCount, int pickedCount)
    : Exception($"in {questionType} type, there is not {questionCount}. you can pick just {pickedCount} questions.");