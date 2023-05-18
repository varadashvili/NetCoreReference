using System.Net;

namespace GlobalErrorHandlingDemo.Common.Errors
{
    public class UserNotFoundException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public string ErrorMessage => "User not found.";
    }
}
