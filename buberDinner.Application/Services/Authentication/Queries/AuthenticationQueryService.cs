using buberDinner.Domain.Errors;
using buberDinner.Application.Common.Interfaces.Authentication;
using buberDinner.Application.Common.Interfaces.Persistence;
using buberDinner.Domain.Entities;
using ErrorOr;
using buberDinner.Application.Services.Authentication.Common;

namespace buberDinner.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository = null)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        // Validate the user exists
        if ( _userRepository.GetUserByEmail(email) is not User user)
        {
           return Errors.Authentication.InvalidCredentials;
        }
        //Validate the password is correct 
        if(user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        //Create JWT token
        var token = _jwtTokenGenerator.GeneratorToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}