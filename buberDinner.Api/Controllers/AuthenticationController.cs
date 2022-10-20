using Microsoft.AspNetCore.Mvc;
using buberDinner.Contracts.Authentication;
using ErrorOr;
using buberDinner.Application.Services.Authentication.Common;
using buberDinner.Application.Services.Authentication.Queries;
using buberDinner.Application.Services.Authentication.Commands;

namespace buberDinner.Api.Controllers;
[ApiController]
 [Route("auth")]
  public class AuthenticationController : ApiController
  {
    private readonly IAuthenticationCommandService _authenticationCommandService;
    private readonly IAuthenticationQueryService _authenticationQueryService;
    public AuthenticationController(
        IAuthenticationCommandService authenticationCommandService,
        IAuthenticationQueryService authenticationQueryService)
    {
        _authenticationCommandService = authenticationCommandService;
        _authenticationQueryService = authenticationQueryService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest req)
    {
        var authResult = _authenticationCommandService.Register(
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
        var authResult = _authenticationQueryService.Login(
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