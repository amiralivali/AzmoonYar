using AzmoonYar.API.DTOs;
using AzmoonYar.API.Intefaces;
using AzmoonYar.API.Models;

namespace AzmoonYar.API.Services;

public class OptionalService: IOptionalService
{
    private static readonly List<OptionalQuestion>? Questions = [];
    private static readonly List<OptionalItem>? Items=[];
    public List<OptionalQuestionDto> GetAll()
    {
        List<OptionalQuestionDto> result = new List<OptionalQuestionDto>();
        if (Questions != null)
            for (int i = 0; i < Questions.Count; i++)
            {
                result.Add(new OptionalQuestionDto(Questions[i].Id, Questions[i].QuestionText, Items![i].Option1,
                    Items[i].Option2, Items[i].Option3, Items[i].Option4));
            }

        return result;
    }

    public void Add(OptionalQuestion question, OptionalItem item)
    {
        Questions?.Add(question);
        Items?.Add(item);
    }

    public void Remove(int id)
    {
        Questions?.Remove(Questions.Find(x => x.Id == id));
        Items?.Remove(Items.Find(x => x.OptionalId == id));
    }

    public void Update(OptionalQuestion question, OptionalItem item)
    {
        if (Questions != null)
        {
            int index = Questions.FindIndex(x => x.Id == question.Id);
            if (index != -1)
            {
                Questions[index] = question;
                Items?[index] = item;
            }
        }
    }
}