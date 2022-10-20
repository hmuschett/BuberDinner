using Microsoft.AspNetCore.Mvc;
using buberDinner.Contracts.Authentication;
using ErrorOr;
using MediatR;
using buberDinner.Application.Authentication.Commands.Register;
using buberDinner.Application.Authentication.Queries.Login;
using buberDinner.Application.Authentication.Common;

namespace buberDinner.Api.Controllers;
[ApiController]
 [Route("auth")]
  public class AuthenticationController : ApiController
  { private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest req)
    {
        var command = new RegisterCommand(req.FirstName,
                                          req.LastName,
                                          req.Email,
                                          req.Password);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginRequest req)
    {
        var command = new LoginQuery(req.Email,
                                    req.Password);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

       return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }
     private static AuthenticationResponse MapAuthResult(ErrorOr<AuthenticationResult> authResult)
    {
        return new AuthenticationResponse(
            authResult.Value.User.Id,
            authResult.Value.User.FirstName,
            authResult.Value.User.LastName,
            authResult.Value.User.Email,
            authResult.Value.Token);
    }
  }