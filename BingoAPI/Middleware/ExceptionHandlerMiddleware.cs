using BingoAPI.Core.Exception;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace BingoAPI.Middleware;

/// <summary>
/// Middleware for handling exceptions and returning appropriate error responses.
/// </summary>
public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHostEnvironment _host;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionHandlerMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next request delegate in the pipeline.</param>
    /// <param name="logger">The logger for logging exceptions.</param>
    /// <param name="host">The hosting environment.</param>
    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger, IHostEnvironment host)
    {
        _next = next;
        _host = host;
        _logger = logger;
    }

    /// <summary>
    /// Invokes the middleware to handle exceptions and return appropriate error responses.
    /// </summary>
    /// <param name="httpContext">The HTTP context.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.InnerException?.Message ?? e.Message);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = _host.IsDevelopment()
                ? new ApiException(httpContext.Response.StatusCode, e.InnerException?.Message ?? e.Message, e.StackTrace?.ToString() ?? "Something went wrong!")
                : new ApiException(httpContext.Response.StatusCode, e.InnerException?.Message ?? e.Message, "Internal Server Error");

            await httpContext.Response.WriteAsJsonAsync(response);
        }
    }
}

/// <summary>
/// Extension methods for registering the <see cref="ExceptionHandlerMiddleware"/> in the application pipeline.
/// </summary>
public static class ExceptionHandlerMiddlewareExtensions
{
    /// <summary>
    /// Adds the <see cref="ExceptionHandlerMiddleware"/> to the application pipeline.
    /// </summary>
    /// <param name="builder">The application builder.</param>
    /// <returns>The updated application builder.</returns>
    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}

