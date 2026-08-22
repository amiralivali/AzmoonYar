using AzmoonYar.Application.Repositories;
using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using AzmoonYar.Domain.Exceptions;

namespace AzmoonYar.Application.Services;

public class AutomaticQuestionSelector(IQuestionRepository repository)
{
    public async Task<IReadOnlyCollection<SelectedQuestionDto>> SelectAsync(
        ICollection<long> lessonIds,
        DifficultyLevel difficultyLevel,
        decimal totalScore,
        IReadOnlyCollection<ExamQuestionTypeDto> questionTypes,
        CancellationToken ct = default)
    {
        if (lessonIds.Count == 0)
            throw new InvalidLessonSelectionException();
 
        var totalCount = questionTypes.Sum(x => x.Count);
        if (totalCount <= 0)
            throw new InvalidQuestionCount();
 
        var lessonIdList = lessonIds.ToList();
        var selectedQuestions = new List<Question>();
 
        foreach (var questionType in questionTypes)
        {
            var picked = await SelectForTypeAsync(lessonIdList, questionType, difficultyLevel, ct);
            selectedQuestions.AddRange(picked);
        }
 
        return BuildScoredResult(selectedQuestions, totalScore);
    }
 
    private async Task<List<Question>> SelectForTypeAsync(
        List<long> lessonIds,
        ExamQuestionTypeDto questionType,
        DifficultyLevel difficultyLevel,
        CancellationToken ct)
    {
        var perLessonTargets = DistributeEvenly(questionType.Count, lessonIds.Count);
        var picked = new List<Question>();
 
        // مرحله ۱: تلاش برای توزیع متناسب بین درس‌ها
        for (var i = 0; i < lessonIds.Count; i++)
        {
            if (perLessonTargets[i] == 0)
                continue;
 
            var candidates = await repository.GetSelectionCandidatesAsync(
                lessonIds[i], questionType.QuestionType, difficultyLevel, ct);
 
            var alreadyPickedIds = picked.Select(p => p.Id).ToHashSet();
            var fresh = candidates.Where(q => !alreadyPickedIds.Contains(q.Id)).ToList();
 
            picked.AddRange(PickWeightedByUsage(fresh, perLessonTargets[i]));
        }
 
        // مرحله ۲: اگر بعضی درس‌ها سوال کافی نداشتن، از بین بقیه‌ی درس‌ها جبران کن
        var shortfall = questionType.Count - picked.Count;
        if (shortfall > 0)
        {
            var pickedIds = picked.Select(q => q.Id).ToHashSet();
            var pool = new List<Question>();
 
            foreach (var lessonId in lessonIds)
            {
                var candidates = await repository.GetSelectionCandidatesAsync(
                    lessonId, questionType.QuestionType, difficultyLevel, ct);
 
                pool.AddRange(candidates.Where(q => !pickedIds.Contains(q.Id)));
            }
 
            var extra = PickWeightedByUsage(pool.DistinctBy(q => q.Id).ToList(), shortfall);
            picked.AddRange(extra);
        }
 
        if (picked.Count < questionType.Count)
            throw new NotEnoughQuestionsException(questionType.QuestionType, questionType.Count, picked.Count);
 
        return picked;
    }
 
    private static int[] DistributeEvenly(int total, int buckets)
    {
        var result = new int[buckets];
        var baseCount = total / buckets;
        var remainder = total % buckets;
 
        for (var i = 0; i < buckets; i++)
            result[i] = baseCount + (i < remainder ? 1 : 0);
 
        return result;
    }
 
    // اولویت با سوالاتی که کمتر استفاده شده‌اند (UsageCount کمتر)؛ بین سوالات هم‌سطح، انتخاب رندوم
    private static List<Question> PickWeightedByUsage(IReadOnlyCollection<Question> candidates, int count)
    {
        if (count <= 0)
            return [];
 
        return candidates
            .OrderBy(q => q.UsageCount)
            .ThenBy(_ => Guid.NewGuid())
            .Take(count)
            .ToList();
    }
 
    private static IReadOnlyCollection<SelectedQuestionDto> BuildScoredResult(
        List<Question> selectedQuestions,
        decimal totalScore)
    {
        var totalCount = selectedQuestions.Count;
        if (totalCount == 0)
            return [];
 
        var scorePerQuestion = Math.Round(totalScore / totalCount, 2);
 
        var result = selectedQuestions
            .Select(q => new SelectedQuestionDto(q.Id, q.QuestionType, scorePerQuestion))
            .ToList();
 
        // اصلاح خطای رند شدن، تا جمع نمرات دقیقاً برابر totalScore بشه
        var roundingDiff = totalScore - result.Sum(x => x.Score);
        if (roundingDiff != 0)
        {
            var last = result[^1];
            result[^1] = last with { Score = last.Score + roundingDiff };
        }
 
        return result;
    }
}