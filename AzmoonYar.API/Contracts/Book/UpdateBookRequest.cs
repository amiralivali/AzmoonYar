using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Book;

public record UpdateBookRequest(string BookName, Grade Grade,string? GradeInfo,List<UpdateLessonRequest> UpdateLessonRequests);