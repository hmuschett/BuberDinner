using buberDinner.Application.Services.Authentication.Common;
using ErrorOr;

namespace buberDinner.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult>  Login(string Email,
                               string Password);
}