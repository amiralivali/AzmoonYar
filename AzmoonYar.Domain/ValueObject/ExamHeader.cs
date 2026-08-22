namespace AzmoonYar.Domain.ValueObject;

public sealed record ExamHeader
{
    public string? SchoolName { get; private set; }
    public string ExamTitle { get; private set; } = null!;
    public string? TeacherName { get; private set; }
    public string? ClassName { get; private set; }
    public DateTimeOffset? ExamDate { get; private set; }
    public int DurationMinutes { get; private set; }
    public string? LogoPicture { get; private set; }

    private ExamHeader()
    {}

    private ExamHeader(
        string? schoolName,
        string examTitle,
        string? teacherName,
        string? className,
        DateTimeOffset? examDate,
        int durationMinutes,
        string? logoPicture)
    {
        SchoolName = schoolName;
        ExamTitle = examTitle;
        TeacherName = teacherName;
        ClassName = className;
        ExamDate = examDate;
        DurationMinutes = durationMinutes;
        LogoPicture = logoPicture;
    }

    public static ExamHeader Create(
        string? schoolName,
        string examTitle,
        string? teacherName,
        string? className,
        DateTimeOffset? examDate,
        int durationMinutes,
        string? logoPicture) =>
        new(schoolName, examTitle, teacherName, className, examDate, durationMinutes, logoPicture);
}