using Microsoft.AspNetCore.Mvc;

namespace UsefulPackagesDemo.Common.Versioning.Controllers.v2;

[ApiVersion("2.0")]
[ApiExplorerSettings(GroupName = "v2")]
public class ValuesController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> GetValues()
    {
        await Task.CompletedTask;

        return Ok();
    }
}
