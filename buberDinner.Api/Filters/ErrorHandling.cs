using System.Net;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace buberDinner.Api.Filters;
public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
     //for config this filter we have to add to the Program.cs in addController service
    public override void OnException(ExceptionContext context)
    {
       var exception = context.Exception;
       var problemDetails = new ProblemDetails{
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "An error occurred while processing your request",
            Status = (int)HttpStatusCode.InternalServerError,
       };
       context.Result = new ObjectResult(problemDetails);
       context.ExceptionHandled = true;
    }
}