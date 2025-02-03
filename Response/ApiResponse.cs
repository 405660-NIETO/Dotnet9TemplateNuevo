using System.Net;

namespace Programacion3Template.Response
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ApiResponse()
        {
            Success = true;
            StatusCode = HttpStatusCode.OK;
            ErrorMessage = string.Empty;
        }

        public void SetError(string errorMessage, HttpStatusCode statusCode)
        {
            Success = false;
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }
    }
}
