using System.Net;

using GlobalErrorHandling.Common.Errors;

using Microsoft.AspNetCore.Diagnostics;
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

        var (statusCode, message) = exception switch
        {
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => ((int)HttpStatusCode.InternalServerError, "An unexpected error occured.")
        };

        var problemResult = Problem(title: message, statusCode: statusCode, instance: path);

        //var problemDetails = problemResult.Value as ProblemDetails;
        //problemDetails.Extensions.Add("customProperty", "customValue");

        return problemResult;

        //return Problem();
    }
}
