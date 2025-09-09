using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;

namespace YoutubeApi.Application.Exceptions;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        int statusCode = GetStatusCode(exception);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        List<string> errrors = new List<string>()
        {
            exception.Message,
            exception.InnerException?.ToString(),
        };

        return context.Response.WriteAsync(
            new ExceptionModel { StatusCode = statusCode, Errors = errrors }.ToString()
        );
    }

    private static int GetStatusCode(Exception exception)
    {
        return exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError,
        };
    }
}
