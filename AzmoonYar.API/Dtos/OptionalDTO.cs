namespace AzmoonYar.API.DTOs;

public class OptionalDTO(int id, int lessonId, string questionText, string picture, int difficultyLevelId, string option1, string option2, string option3, string option4)
{
    public int Id { get; set; } = id;
    public int LessonId { get; set; } = lessonId;
    [Required]
    [MaxLength(200)]
    public string QuestionText { get; set; } = questionText;
    public string Picture { get; set; }= picture;
    [Rage(1,4)]
    public int DifficultyLevelId { get; set; }= difficultyLevelId;
    [Required]
    [MaxLength(80)]
    public string Option1 { get; set; }= option1;
    [Required]
    [MaxLength(80)]
    public string Option2 { get; set; }=option2;
    [Required]
    [MaxLength(80)]
    public string Option3 { get; set; }=option3;
    [Required]
    [MaxLength(80)]
    public string Option4 { get; set; }=option4;
}