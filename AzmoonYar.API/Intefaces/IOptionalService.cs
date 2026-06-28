using System.Runtime;
using AzmoonYar.API.DTOs;
using AzmoonYar.API.Models;

namespace AzmoonYar.API.Intefaces;

public interface IOptionalService
{
    public List<OptionalDTO> GetAll();
    public void Add(Mapper question,OptionalItem item);
    public void Remove(int id);
    public void Update(Mapper question,OptionalItem item);
}