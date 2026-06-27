using AzmoonYar.API.Intefaces;
using AzmoonYar.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzmoonYar.API.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class OptionalQuestionController(IOptionalService optionalService) : ControllerBase
{
    [HttpPost]
    public IActionResult Add([FromBody]AddOptionalQuestionRequest values)
    {
        optionalService.Add(values.Question, values.Item);
        return Ok();
    }
    [HttpDelete]
    public IActionResult Remove(int id)
    {
        optionalService.Remove(id);
        return Ok();
    }
    [HttpPost]
    public IActionResult Update([FromBody]AddOptionalQuestionRequest values)
    {
        optionalService.Update(values.Question, values.Item);
        return Ok();
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var result = optionalService.GetAll();
        return Ok(result);
    }
}