using Microsoft.AspNetCore.Mvc;
using buberDinner.Contracts.Authentication;
using buberDinner.Application.Services.Authentication;
using ErrorOr;

namespace buberDinner.Api.Controllers;
 [ApiController]
 [Route("auth")]
  public class AuthenticationController : ApiController
  {
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest req)
    {
        var authResult = _authenticationService.Register(
            req.FirstName,
            req.LastName,
            req.Email,
            req.Password);
        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest req){
        var authResult = _authenticationService.Login(
            req.Email,
            req.Password);

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