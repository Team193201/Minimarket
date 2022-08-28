using Infrastructure.Util;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Middlewares
{
    public class CustomExceptionHandler
    {
        private readonly RequestDelegate _next;
        private DataAppException DataApp { get; set; }

        public CustomExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException exception)
            {
                DataApp = exception.DataApp;
                throw;
            }
            catch (Exception exception)
            {
                DataApp = new DataAppException();
                throw exception.InnerException;
            }
            finally
            {
                // logg error
            }
        }
    }
}
