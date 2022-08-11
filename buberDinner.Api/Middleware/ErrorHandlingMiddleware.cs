
using System.Net;
using System.Text.Json;

namespace buberDinner.Api.Middleware;
public class ErrorHandlingMiddleware{
    //for config this middleware we have to add to the Program.cs
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context){
        try
        {
            await _next(context);
        }
        catch(Exception ex){
            await HandleExceptionAsync(context, ex);
        }
    }

    public static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = JsonSerializer.Serialize(new {error = "An error occurred while processing your request.", ExceptionMessage = ex.Message});
        context.Response.ContentType= "application/json";
        context.Response.StatusCode = (int) code;
        return context.Response.WriteAsync(result);
    }
}