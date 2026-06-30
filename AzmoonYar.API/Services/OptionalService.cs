using AzmoonYar.API.Dtos;
using AzmoonYar.API.Intefaces;
using AzmoonYar.API.Mapper;
using AzmoonYar.API.Models;

namespace AzmoonYar.API.Services;

public class OptionalService:IOptionalService
{
    private static List<OptionalQuestion?>? Questions = new List<OptionalQuestion?>();


    public List<OptionalDto> GetAll()
    {
        List<OptionalDto> optionals = new List<OptionalDto>();
        if (Questions != null)
            foreach (var optional in Questions)
            {
                if (optional != null) optionals.Add(optional.MapToDto());
            }

        return optionals;
    }

    public void Add(OptionalQuestion question)
    {
        Questions?.Add(question);
    }

    public void Remove(int id)
    {
        Questions?.Remove(Questions.Find(x => x!.Id == id));
    }

    public void Update(OptionalQuestion question)
    {
        if (Questions != null)
        {
            int index = Questions.FindIndex(x => x!.Id == question.Id);
            if (index != -1)
            {
                Questions[index] = question;
            }
        }
    }
}