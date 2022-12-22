using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace GlobalErrorHandling.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = exceptionHandlerFeature?.Error;
        var path = exceptionHandlerFeature?.Path;

        var problemResult = Problem(title: exception.Message, statusCode: 400, instance: path);
        var problemDetails = problemResult.Value as ProblemDetails;
        //problemDetails.Extensions.Add("customProperty2", "customValue2");

        return problemResult;

        //return Problem();
    }
}
