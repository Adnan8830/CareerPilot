using System.Text.Json;
using CareerPilot.Application.Exceptions;

 namespace CareerPilot.API.Middleware;

    public class ExceptionHandlingMiddleware
    {
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            Console.WriteLine($"Exception Type: {ex.GetType().FullName}");
            context.Response.StatusCode = ex switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                NotFoundException  => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            var response = new
            {
                Success = false,
                Message = ex.Message

            };


            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }

}

