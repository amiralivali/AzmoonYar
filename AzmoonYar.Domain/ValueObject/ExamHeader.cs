namespace AzmoonYar.Domain.ValueObject;

public sealed record ExamHeader
{
    public string? SchoolName { get; private set; }
    public string? ExamTitle { get; private set; }
    public string? TeacherName { get; private set; }
    public string? ClassName { get; private set; }
    public DateTimeOffset? ExamDate { get; private set; }
    public int? DurationMinutes { get; private set; }
    public string? LogoPicture { get; private set; }
    public string? HeaderPicture { get; private set; } // this use except all the props

    public static ExamHeader Empty() => new();

    public static ExamHeader FromImage(string headerPicture) =>
        new() { HeaderPicture = headerPicture };

    public static ExamHeader Custom(
        string? schoolName,
        string? examTitle,
        string? teacherName,
        string? className,
        DateTimeOffset? examDate,
        int? durationMinutes,
        string? logoPicture = null) =>
        new()
        {
            SchoolName = schoolName,
            ExamTitle = examTitle,
            TeacherName = teacherName,
            ClassName = className,
            ExamDate = examDate,
            DurationMinutes = durationMinutes,
            LogoPicture = logoPicture
        };
}