using CustomFluentValidation.Models;

using FluentValidation;
using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Mvc;

namespace CustomFluentValidation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksMVController : ControllerBase
{
    private readonly IValidator<TaskItem> _validator;

    public TasksMVController(IValidator<TaskItem> validator)
    {
        _validator = validator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(TaskItem item)
    {
        //manual validation
        var validationResult = await _validator.ValidateAsync(item);

        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);

            return ValidationProblem(this.ModelState);
        }

        return Ok(item);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(
        TaskItem item,
        [FromServices] IValidator<TaskItem> validator)
    {
        //manual validation
        var validationResult = await validator.ValidateAsync(item);

        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);

            return ValidationProblem(this.ModelState);
        }

        return Ok(item);
    }
}
