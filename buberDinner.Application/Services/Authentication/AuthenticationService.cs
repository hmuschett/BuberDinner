using buberDinner.Application.Common.Interfaces.Authentication;

namespace buberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        //Check is user already exist

        //Create user (Generate unique Id)

        //Create JWT Token
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GeneratorToken(userId, FirstName, LastName);

         return new AuthenticationResult(Guid.NewGuid(),
                                         FirstName,
                                         LastName,
                                         Email,
                                         token);
    }
    public AuthenticationResult Login(string Email, string Password)
    {
        return new AuthenticationResult(Guid.NewGuid(),
                                        "firstName",
                                        "lastName",
                                        Email,
                                        Password);
    }
}