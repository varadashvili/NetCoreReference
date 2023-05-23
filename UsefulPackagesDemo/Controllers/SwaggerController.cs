using Microsoft.AspNetCore.Mvc;

using UsefulPackagesDemo.Common.Swagger.Dtos;

namespace UsefulPackagesDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SwaggerController : ControllerBase
{
    /// <summary>
    /// retrieves system info
    /// </summary>
    /// <remarks>use this method to get system info</remarks>
    /// <response code="200">connection succeeded</response>
    /// <response code="500">connection failed or internal server error occured</response>
    [ProducesResponseType(typeof(SystemInfoDto), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    [HttpGet]
    [Route("GetServerDate")]
    public async Task<IActionResult> GetSystemInfo()
    {
        await Task.CompletedTask;

        var response = new SystemInfoDto
        {
            SystemDate = DateTime.Now,
        };

        return Ok(response);
    }
}
