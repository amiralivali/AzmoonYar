using System.ComponentModel.DataAnnotations;

namespace AzmoonYar.API.Dtos;

public class OptionalDto
{
    public OptionalDto(int id, int lessonId, string questionText, string picture, int difficultyLevelId, string option1, string option2, string option3, string option4)
    {
        Id = id;
        LessonId = lessonId;
        QuestionText = questionText;
        Picture = picture;
        DifficultyLevelId = difficultyLevelId;
        Option1 = option1;
        Option2 = option2;
        Option3 = option3;
        Option4 = option4;
    }

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