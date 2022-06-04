using System;
using System.Text.Json;
using System.Threading.Tasks;
using Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Common.Middlewares
{
    public sealed class ExceptionHandlingMiddleware : IMiddleware
    {
        public ExceptionHandlingMiddleware() { }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);

                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = exception switch
            {
                BadRequestException badRequestException => StatusCodes.Status400BadRequest,
                NotFoundException notFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            var response = new
            {
                error = exception.Message
            };

            Log.Error(exception, exception.Message);

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}