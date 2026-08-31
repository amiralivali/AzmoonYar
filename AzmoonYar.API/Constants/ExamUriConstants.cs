namespace AzmoonYar.API.Constants;

public static class ExamUriConstants
{
    private const string Controller = "Exam";
    
    public const string GetAll = $"{Controller}";
    public const string GenerateExamPdf = $"{Controller}/Pdf/{{exam}}";
}