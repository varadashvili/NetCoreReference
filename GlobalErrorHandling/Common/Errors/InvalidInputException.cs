﻿using System.Net;

namespace GlobalErrorHandlingDemo.Common.Errors
{
    public class InvalidInputException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public string ErrorMessage => "Invalid input.";
    }
}
