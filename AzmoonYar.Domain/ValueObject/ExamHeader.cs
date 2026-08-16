namespace AzmoonYar.Domain.ValueObject;

public sealed record ExamHeader
{
    public string? HeaderPicture { get; init; }
    public string? LogoPicture { get; init; }
    public string? HeaderText { get; init; }

    private ExamHeader()
    {
    }

    public static ExamHeader FromImage(string headerPicture)
    {
        return new ExamHeader { HeaderPicture = headerPicture };
    }

    public static ExamHeader Custom(string headerText, string? logoPicture = null)
    {
        return new ExamHeader { HeaderText = headerText, LogoPicture = logoPicture };
    }

    public static ExamHeader Empty() => new();
}