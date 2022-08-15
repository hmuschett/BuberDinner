using buberDinner.Application.Common.Errors;
using buberDinner.Application.Common.Interfaces.Authentication;
using buberDinner.Application.Common.Interfaces.Persistence;
using buberDinner.Domain.Entities;

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

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Check is user already exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new DuplicateEmailException();
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
    public AuthenticationResult Login(string email, string password)
    {
        // Validate the user exists
        if ( _userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email does not exists");
        }
        //Validate the password is correct 
        if(user.Password != password)
        {
             throw new Exception("Invalid password.");
        }
        //Create JWT token
        var token = _jwtTokenGenerator.GeneratorToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}