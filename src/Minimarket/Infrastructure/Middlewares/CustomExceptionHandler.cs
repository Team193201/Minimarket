using Infrastructure.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Sheard;

namespace Infrastructure.Middlewares
{
    /// <summary>
    /// Middleware for handler exception in app ,
    /// Create valid result from exception for client and logg error  if that is necessary
    /// </summary>
    public class CustomExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _environment;

        public CustomExceptionHandler(RequestDelegate next, IHostEnvironment environment)
        {
            _next = next;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException exception)
            {
                await FixException(_environment, context, exception);
            }
            catch (Exception exception)
            {
                await FixException(_environment, context, exception);
            }
            finally
            {
                // logg error
            }
        }

        private async Task FixException(IHostEnvironment _environment, HttpContext context, Exception exception)
        {
            string message = string.Empty;
            if (_environment.IsDevelopment())
            {
                var dic = new Dictionary<string, string>
                {
                    ["ExceptionMessage"] = exception.Message,
                    ["ExceptionStackTrace"] = exception.StackTrace,
                };

                if (exception.InnerException != null)
                {
                    dic.Add("InnerException.Exception", exception.InnerException.Message);
                    dic.Add("InnerException.StackTrace", exception.InnerException.StackTrace);
                }

                dic.Add("ExceptionDateTime", DateTime.UtcNow.ToString("f"));

                message = JsonConvert.SerializeObject(dic);

                //TODO : think about new DataAppException() without any send data to this record
                await WriteToResponseAsync(context, new DataAppException(), message);
            }
            else
            {
                await WriteToResponseAsync(context, new DataAppException(), exception.Message);
            }
        }

        private async Task FixException(IHostEnvironment _environment, HttpContext context, AppException exception)
        {
            string message = string.Empty;
            if (_environment.IsDevelopment())
            {
                var dic = new Dictionary<string, string>
                {
                    ["ExceptionMessage"] = exception.Message,
                    ["ExceptionStackTrace"] = exception.StackTrace,
                };

                if (exception.InnerException != null)
                {
                    dic.Add("InnerException.Exception", exception.InnerException.Message);
                    dic.Add("InnerException.StackTrace", exception.InnerException.StackTrace);
                }
                if (!string.IsNullOrEmpty(exception.DataApp.AdditionalData))
                    dic.Add("ExceptionAdditionalData", exception.DataApp.AdditionalData);
                dic.Add("ExceptionDateTime", DateTime.UtcNow.ToString("f"));

                message = JsonConvert.SerializeObject(dic);

                await WriteToResponseAsync(context, exception.DataApp, message);
            }
            else
            {
                await WriteToResponseAsync(context, exception.DataApp, exception.Message);
            }
        }

        private async Task WriteToResponseAsync(HttpContext context, DataAppException dataApp, string message)
        {
            if (context.Response.HasStarted)
                throw new InvalidOperationException("The response has already started, the http status code middleware will not be executed.");

            var result = new ApiResult(dataApp.AdditionalData, dataApp.HttpStatusCode, message);
            var json = JsonConvert.SerializeObject(result);

            context.Response.StatusCode = (int)dataApp.HttpStatusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);
        }
    }
}