using Microsoft.AspNetCore.Mvc;

namespace UsefulPackagesDemo.Common.Versioning.Controllers;

[Route("api/v{version:ApiVersion}/[controller]")]
[ApiController]
public class ApiController : ControllerBase
{

}
