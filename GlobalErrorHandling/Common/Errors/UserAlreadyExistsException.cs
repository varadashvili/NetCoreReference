using System.Net;

namespace GlobalErrorHandlingDemo.Common.Errors;

public class UserAlreadyExistsException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public string ErrorMessage => "User already exists.";
}