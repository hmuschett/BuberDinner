using buberDinner.Domain.Errors;
using buberDinner.Application.Common.Interfaces.Authentication;
using buberDinner.Application.Common.Interfaces.Persistence;
using buberDinner.Domain.Entities;
using ErrorOr;

namespace buberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository = null)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        //Check is user already exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        //Create user (Generate unique Id) & persistence
        var user = new User{
            FirstName= firstName,
            LastName= lastName,
            Email= email,
            Password= password
        };

        _userRepository.Add(user);

        //Create JWT Token        
        var token = _jwtTokenGenerator.GeneratorToken(user);

         return new AuthenticationResult(
             user,
             token);
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