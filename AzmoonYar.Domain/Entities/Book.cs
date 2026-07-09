using AzmoonYar.Domain.Enums;

namespace AzmoonYar.Domain.Entities;

public class Book
{
    public long Id { get; private set; }
    public string BookName { get; private set; } = null!;
    public Grade Grade { get; private set; } 
    public string? GradeInfo { get; private set; }
    public ICollection<Lesson> Lessons { get; private set; } = null!;
    
    private Book()
    {
        
    }
    public Book(long id, string bookName, Grade grade)
    {
        Id = id;
        BookName = bookName;
        Grade = grade;
    }
}