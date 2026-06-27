using System.Runtime;
using AzmoonYar.API.DTOs;
using AzmoonYar.API.Models;

namespace AzmoonYar.API.Intefaces;

public interface IOptionalService
{
    public List<OptionalQuestionDto> GetAll();
    public void Add(OptionalQuestion question,OptionalItem item);
    public void Remove(int id);
    public void Update(OptionalQuestion question,OptionalItem item);
}