using System.Net;

namespace Sheard
{
    public class ApiResult
    {
        public ApiResult(object result, HttpStatusCode httpStatusCode = HttpStatusCode.OK, string message = null, List<string> error = null)
        {
            HttpStatusCode = httpStatusCode;
            Message = string.IsNullOrEmpty(message) ? "every thing is ok!" : message;
            Result = result;
            Error = error;
        }

        public HttpStatusCode HttpStatusCode { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
        public List<string> Error { get; set; }
    }
}
