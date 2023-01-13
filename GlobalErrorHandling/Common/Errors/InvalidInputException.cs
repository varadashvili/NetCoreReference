using System.Net;

namespace GlobalErrorHandling.Common.Errors
{
    public class InvalidInputException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public string ErrorMessage => "Invalid input.";
    }
}
