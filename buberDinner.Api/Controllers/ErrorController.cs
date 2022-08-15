using buberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace buberDinner.Api.Controllers;
public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            DuplicateEmailException => (StatusCodes.Status409Conflict, "Email already exists."),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
        };
        return Problem(
            title: message,
            statusCode: statusCode);
    }
}