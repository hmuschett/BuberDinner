using buberDinner.Application.Services.Authentication.Common;
using ErrorOr;

namespace buberDinner.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string FirstName,
                                  string LastName,
                                  string Email,
                                  string Password);
}