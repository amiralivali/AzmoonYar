using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Book;

public record CreateBookRequest(string BookName, Grade Grade,string? GradeInfo,List<CreateLessonRequest> LessonRequests);