using System.Net;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc;

namespace GlobalErrorHandling.Middleware;

//catches any exception and wraps response
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public ErrorHandlingMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _requestDelegate(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var errorCode = HttpStatusCode.InternalServerError;
        var errorMessage = exception.Message;

        var problemDetails = new ProblemDetails
        {
            Title = errorMessage,
            Status = (int)errorCode,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Instance = httpContext.Request.Path
        };
        problemDetails.Extensions.Add("customProperty", "customValue");

        var contentString = JsonSerializer.Serialize(problemDetails);

        httpContext.Response.ContentType = "application/problem+json;";
        httpContext.Response.StatusCode = (int)errorCode;

        return httpContext.Response.WriteAsync(contentString);
    }
}
