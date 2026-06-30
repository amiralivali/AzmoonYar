using AzmoonYar.API.Dtos;
using AzmoonYar.API.Models;

namespace AzmoonYar.API.Mapper;

public static class Mapper
{
    public static OptionalQuestion MapToOptional(this OptionalDto dto)
    {
        return new OptionalQuestion(dto.Id,dto.LessonId,dto.QuestionText,dto.Picture
        ,dto.DifficultyLevelId,dto.Option1, dto.Option2, dto.Option3, dto.Option4);
    }
    public static OptionalDto MapToDto(this OptionalQuestion dto)
    {
        return new OptionalDto(dto.Id,dto.LessonId,dto.QuestionText,dto.Picture
            ,dto.DifficultyLevelId,dto.Option1, dto.Option2, dto.Option3, dto.Option4);
    }
    public static User MapToUser(this UserDto dto)
    {
        return new User(dto.Guid,dto.Username,dto.Password);
    }
}