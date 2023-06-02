using Microsoft.AspNetCore.Mvc;

using UsefulPackagesDemo.Common.Swagger.Contracts;

namespace UsefulPackagesDemo.Common.Swagger.Controllers;

[Route("api/[controller]")]
[ApiVersion("2.0")]
[ApiVersion("3.0")]
[ApiController]
public class SwaggerController : ControllerBase
{
    /// <summary>
    /// retrieves system info
    /// </summary>
    /// <remarks>use this method to get **system info**</remarks>
    /// <response code="200">connection succeeded</response>
    /// <response code="500">connection failed or internal server error occured</response>
    [ProducesResponseType(typeof(SystemInfo), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    [HttpGet]
    [Route("GetServerDate")]
    public async Task<IActionResult> GetSystemInfo()
    {
        await Task.CompletedTask;

        var response = new SystemInfo
        {
            SystemDate = DateTime.Now,
        };

        return Ok(response);
    }

    /// <summary>
    /// get task
    /// </summary>
    /// <remarks>use this method to get task by id</remarks>
    /// <param name="id">task item id</param>
    /// <response code="200">request successfull</response>
    /// <response code="500">internal server error occured</response>
    [ProducesResponseType(typeof(TaskItem), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    [HttpGet]
    public async Task<IActionResult> GetTask(int id)
    {
        await Task.CompletedTask;

        var task = new TaskItem { Id = id };

        return Ok(task);
    }


    /// <summary>
    /// add new task
    /// </summary>
    /// <remarks>use this method to add new task</remarks>
    /// <param name="taskItem">task item info</param>
    /// <response code="201">task created</response>
    /// <response code="500">internal server error occured</response>
    [ProducesResponseType(typeof(TaskItem), 201)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    [HttpPost]
    public async Task<IActionResult> PostTask(TaskItem taskItem)
    {
        await Task.CompletedTask;

        return Created($"api/v1/{taskItem.Id}", taskItem);
    }
}
