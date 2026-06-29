using System.Runtime;
using AzmoonYar.API.Dtos;
using AzmoonYar.API.Models;

namespace AzmoonYar.API.Intefaces;

public interface IOptionalService
{
    public List<OptionalDto> GetAll();
    public void Add(OptionalQuestion question);
    public void Remove(int id);
    public void Update(OptionalQuestion question);
}