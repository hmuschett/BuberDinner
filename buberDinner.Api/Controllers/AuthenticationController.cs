using Microsoft.AspNetCore.Mvc;
using buberDinner.Contracts.Authentication;
using buberDinner.Application.Services.Authentication;

namespace buberDinner.Api.Controllers;
 [ApiController]
 [Route("auth")]
  public class AuthenticationController : ControllerBase
  {
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest req){
        var authResult = _authenticationService.Register(
            req.FirstName,
            req.LastName,
            req.Email,
            req.Password);
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest req){
        var authResult = _authenticationService.Login(
            req.Email,
            req.Password);

        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);
        return Ok(response);
    }
  }