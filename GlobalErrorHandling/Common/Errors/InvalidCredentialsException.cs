using System.Net;

namespace GlobalErrorHandling.Common.Errors
{
    public class InvalidCredentialsException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string ErrorMessage => "Invalid credentials.";
    }
}
