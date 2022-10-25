using buberDinner.Application.Authentication.Common;
using buberDinner.Application.Common.Interfaces.Authentication;
using buberDinner.Application.Common.Interfaces.Persistence;
using buberDinner.Domain.Entities;
using ErrorOr;
using MediatR;

namespace buberDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository,
                                  IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
       // Validate the user exists
        if ( _userRepository.GetUserByEmail(query.Email) is not User user)
        {
           return Domain.Errors.Errors.Authentication.InvalidCredentials;
        }
        //Validate the password is correct 
        if(user.Password != query.Password)
        {
            return Domain.Errors.Errors.Authentication.InvalidCredentials;
        }
        //Create JWT token
        var token = _jwtTokenGenerator.GeneratorToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}