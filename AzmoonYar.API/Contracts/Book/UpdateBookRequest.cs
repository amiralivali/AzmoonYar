using AzmoonYar.Domain.Enums;

namespace AzmoonYar.API.Contracts.Book;

public record UpdateBookRequest(string BookName, Grade Grade,BookSource BookSource,List<UpdateLessonRequest> UpdateLessonRequests,IFormFile? CoverImage);