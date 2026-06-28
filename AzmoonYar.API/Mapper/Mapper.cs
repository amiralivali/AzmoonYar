using AzmoonYar.API.Controllers;
using AzmoonYar.API.DTOs;

namespace AzmoonYar.API.Models;

public static class Mapper()
{
    public static OptionalQuestion MapToOptional(this OptionalDTO optionalDTO)
    {
        return new OptionalQuestion(optionalDTO.Id, optionalDTO.QuestionText, optionalDTO.Picture, optionalDTO.DifficultyLevelId, optionalDTO.Option1, optionalDTO.Option2, optionalDTO.Option3, optionalDTO.Option4);
    }
}   