using FluentValidation.Models;

using Microsoft.AspNetCore.Mvc;

namespace FluentValidation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    [HttpPost]
    public TaskItem Post(TaskItem item)
    {
        return item;
    }
}
