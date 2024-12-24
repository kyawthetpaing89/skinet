using System.Net;
using System.Text.Json;
using skinet.Errors;

namespace skinet.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
    {
        private static readonly JsonSerializerOptions _jsonoption = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionMiddleware> _logger = logger;
        private readonly IHostEnvironment _env = env;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred: {ErrorMessage}", ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                    ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace!.ToString())
                    : new ApiException((int)HttpStatusCode.InternalServerError);


                var json = JsonSerializer.Serialize(response, _jsonoption);

                await context.Response.WriteAsync(json);
            }
        }
    }
}