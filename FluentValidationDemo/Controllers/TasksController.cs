using FluentValidationDemo.Models;

using Microsoft.AspNetCore.Mvc;

namespace FluentValidationDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    [HttpPost]
    public IActionResult Post(TaskItem item)
    {
        return Ok(item);
    }
}
