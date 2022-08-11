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
       var errorResult = new {error = "An error occurred while processing your request"};
       context.Result = new ObjectResult(errorResult)
       {
            StatusCode= 500
       };
       context.ExceptionHandled = true;
    }
}