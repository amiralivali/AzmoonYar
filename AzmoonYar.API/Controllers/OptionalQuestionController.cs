using AzmoonYar.API.ActionFilters;
using AzmoonYar.API.Dtos;
using AzmoonYar.API.Intefaces;
using AzmoonYar.API.Mapper;
using AzmoonYar.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class OptionalQuestion : ControllerBase
{
    public OptionalQuestion(IOptionalService optionalService)
    {
        _optionalService = optionalService;
    }

    private readonly IOptionalService _optionalService;

    [HttpPost]
    public IActionResult Add([FromBody]OptionalDto entity)
    {
        var option = entity.MapToOptional();
        _optionalService.Add(option);
        return Ok();
    }
    [HttpDelete]
    [ServiceFilter(typeof(AuthorizeActionFilter))]
    public IActionResult Remove(int id)
    {
        _optionalService.Remove(id);
        return Ok();
    }
    [HttpPost]
    public IActionResult Update([FromBody] OptionalDto entity)
    {
        var option = entity.MapToOptional();
        _optionalService.Update(option);
        return Ok();
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _optionalService.GetAll();
        return Ok(result);
    }
}