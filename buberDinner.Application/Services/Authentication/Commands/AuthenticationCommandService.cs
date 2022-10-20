using buberDinner.Domain.Errors;
using buberDinner.Application.Common.Interfaces.Authentication;
using buberDinner.Application.Common.Interfaces.Persistence;
using buberDinner.Domain.Entities;
using ErrorOr;
using buberDinner.Application.Services.Authentication.Common;

namespace buberDinner.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository = null)
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
   
}