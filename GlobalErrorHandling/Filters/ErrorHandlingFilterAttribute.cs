using System.Net;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GlobalErrorHandlingDemo.Filters;

//catches unhandled exceptions, cant catch HttpResponseException
public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new ProblemDetails
        {
            Title = exception.Message,
            Status = (int)HttpStatusCode.InternalServerError,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Instance = context.HttpContext.Request.Path
        };
        problemDetails.Extensions.Add("customProperty", "customValue");

        context.Result = new ObjectResult(problemDetails);

        context.ExceptionHandled = true;
    }
}