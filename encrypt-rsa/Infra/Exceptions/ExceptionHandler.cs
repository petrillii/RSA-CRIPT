using Newtonsoft.Json;
using System.Net;

namespace encrypt_rsa.Infra.Exceptions
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null) return;

            var code = HttpStatusCode.InternalServerError;

            if (exception is ArgumentException)
            {
                code = HttpStatusCode.BadRequest;
            }
            else if (exception is KeyNotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }
            else if (exception is UnauthorizedAccessException)
            {
                code = HttpStatusCode.Unauthorized;
            }
            else if (exception is InvalidOperationException)
            {
                code = HttpStatusCode.Unauthorized;
            }

            await WriteExceptionAsync(context, exception, code).ConfigureAwait(false);
        }

        private async Task WriteExceptionAsync(HttpContext context, Exception exception, HttpStatusCode code)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)code;

            var internalError = new Dictionary<string, string>{
                {"message", "Não foi possível completar a operação solicitada devido a um erro interno no servidor." }
            };

            Console.WriteLine(exception.Message);

            if (exception.Data.Count > 0)
                await response.WriteAsync(JsonConvert
                    .SerializeObject(
                    response.StatusCode != 500
                        ? exception.Data ?? null
                        : internalError)).ConfigureAwait(false);
            else
                await response.Body.FlushAsync();
        }

    }
}