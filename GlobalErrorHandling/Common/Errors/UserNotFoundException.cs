using System.Net;

namespace GlobalErrorHandling.Common.Errors
{
    public class UserNotFoundException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public string ErrorMessage => "User not found.";
    }
}
