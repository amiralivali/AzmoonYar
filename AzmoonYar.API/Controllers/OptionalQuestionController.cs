using AzmoonYar.API.DTOs;
using AzmoonYar.API.Intefaces;
using AzmoonYar.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class OptionalQuestion(IOptionalService optionalService) : ControllerBase
{
    [HttpPost]
    public IActionResult Add([FromBody]OptionalDTO entity)
    {
        var option = entity.MapToOptional();
        optionalService.Add(option);
        return Ok();
    }
    [HttpDelete]
    public IActionResult Remove(int id)
    {
        optionalService.Remove(id);
        return Ok();
    }
    [HttpPost]
    public IActionResult Update([FromBody] OptionalDTO entity)
    {
        var option = entity.MapToOptional();
        optionalService.Update(option);
        return Ok();
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var result = optionalService.GetAll();
        return Ok(result);
    }
}