using Microsoft.AspNetCore.Diagnostics;

namespace eCommerce.API.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            // Log the exception type and message
            logger.LogError($"{ex.GetType().ToString()}: {ex.Message}");
            
            // Log the inner exception
            if (ex.InnerException is not null)
                logger.LogError($"{ex.InnerException.GetType().ToString()}: {ex.InnerException.Message}");
            
            context.Response.StatusCode = 500; // Internal Server Error
            await context.Response.WriteAsJsonAsync(new { message = ex.Message , exception = ex.GetType().ToString() });
        }
    }
}

public static class ExceptionHandlingMiddlewareExtension
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}