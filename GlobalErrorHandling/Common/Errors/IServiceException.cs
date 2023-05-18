using System.Net;

namespace GlobalErrorHandlingDemo.Common.Errors;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }

    public string ErrorMessage { get; }
}