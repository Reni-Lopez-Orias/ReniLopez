using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;


namespace Backend.Api
{
    public class SwaggerAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public SwaggerAuthorizationMiddleware(RequestDelegate next, ILogger<SwaggerAuthorizationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
#if !DEBUG
                _logger.LogWarning($"API documentation endpoint unauthorized access attempt by [{context.Connection.RemoteIpAddress}]");
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
#endif
            }

            await _next.Invoke(context);
        }
    }
}
