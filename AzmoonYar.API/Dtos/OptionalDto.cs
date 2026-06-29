using System.ComponentModel.DataAnnotations;

namespace AzmoonYar.API.Dtos;

public class OptionalDto
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    [Required]
    [MaxLength(200)]
    public string QuestionText { get; set; } 
    public string Picture { get; set; }
    [Range(1,4)]
    public int DifficultyLevelId { get; set; }
    [Required]
    [MaxLength(80)]
    public string Option1 { get; set; }
    [Required]
    [MaxLength(80)]
    public string Option2 { get; set; }
    [Required]
    [MaxLength(80)]
    public string Option3 { get; set; }

    [Required] [MaxLength(80)] 
    public string Option4 { get; set; }
}