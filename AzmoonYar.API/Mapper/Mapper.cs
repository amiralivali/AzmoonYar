using AzmoonYar.API.Dtos;
using AzmoonYar.API.Models;

namespace AzmoonYar.API.Mapper;

public static class Mapper
{
    public static OptionalQuestion MapToOptional(this OptionalDto dto)
    {
        return new OptionalQuestion()
        {
            Id = dto.Id,
            Option1 = dto.Option1,
            Option2 = dto.Option2,
            Option3 = dto.Option3,
            Option4 = dto.Option4,
            Picture = dto.Picture,
            LessonId = dto.LessonId,
            DifficultyLevelId = dto.DifficultyLevelId,
            QuestionText = dto.QuestionText
        };
    }
    public static OptionalDto MapToDto(this OptionalQuestion dto)
    {
        return new OptionalDto()
        {
            Id = dto.Id,
            Option1 = dto.Option1,
            Option2 = dto.Option2,
            Option3 = dto.Option3,
            Option4 = dto.Option4,
            Picture = dto.Picture,
            LessonId = dto.LessonId,
            DifficultyLevelId = dto.DifficultyLevelId,
            QuestionText = dto.QuestionText
        };
    }
}