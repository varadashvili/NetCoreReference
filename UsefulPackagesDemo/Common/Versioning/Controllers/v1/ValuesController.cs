using Microsoft.AspNetCore.Mvc;

namespace UsefulPackagesDemo.Common.Versioning.Controllers.v1;

[ApiVersion("3.0")]
[ApiExplorerSettings(GroupName = "v3")]
public class ValuesController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> GetValues()
    {
        await Task.CompletedTask;

        return Ok();
    }
}
