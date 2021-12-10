using System.Net;

namespace CarProject.Core.Model
{
    public class ApiResponse
    {
        public static ApiResponse Create(HttpStatusCode statusCode, object result = null, string message = null, string errorMessage = null)
        {
            return new ApiResponse(statusCode, result, message, errorMessage);
        }
        public string ErrorMessage { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public object Result { get; set; }

        protected ApiResponse(HttpStatusCode statusCode, object result = null, string message = null, string errorMessage = null)
        {
            Result = result;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
            Message = message;
        }
    }
}
