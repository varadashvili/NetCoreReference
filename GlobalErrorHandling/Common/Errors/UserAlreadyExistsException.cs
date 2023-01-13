using System.Net;

namespace GlobalErrorHandling.Common.Errors;

public class UserAlreadyExistsException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public string ErrorMessage => "User already exists.";
}