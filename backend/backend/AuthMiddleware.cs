using System;
using System.Text;
using System.Threading.Tasks;
using Backend.Servicios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Backend.Api
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public AuthMiddleware(RequestDelegate next, ILogger<SwaggerAuthorizationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                string authHeader = httpContext.Request.Headers["Authorization"];
                if (authHeader != null)
                {
                    string auth = authHeader.Split(new char[] { ' ' })[1];
                    Encoding encoding = Encoding.GetEncoding("UTF-8");
                    var usernameAndPassword = encoding.GetString(Convert.FromBase64String(auth));
                    string username = usernameAndPassword.Split(new char[] { ':' })[0];
                    string password = usernameAndPassword.Split(new char[] { ':' })[1];

                    //se validan las credenciales
                    if (username == "ABC123" && password == "ABC123")
                    {
                        await _next(httpContext);
                    }
                    else
                    {
                        httpContext.Response.StatusCode = 401;
                        return;
                    }
                }
                else
                {
                    httpContext.Response.StatusCode = 401;
                    return;
                }
            }
            catch (Exception ex)
            {
                LogService.RegistroLogs(ex, "AuthMiddleware", this._logger);
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }
        }
    }

    public static class BasicAuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseBasicAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }

}


