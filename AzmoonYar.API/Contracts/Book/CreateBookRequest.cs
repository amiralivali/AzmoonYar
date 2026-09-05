using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Book;

public record CreateBookRequest(string BookName, Grade Grade,BookSource BookSource,List<CreateLessonRequest> LessonRequests,IFormFile? CoverImage);