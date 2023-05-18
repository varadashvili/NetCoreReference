using System.Net;

namespace GlobalErrorHandlingDemo.Common.Errors
{
    public class InvalidCredentialsException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string ErrorMessage => "Invalid credentials.";
    }
}
