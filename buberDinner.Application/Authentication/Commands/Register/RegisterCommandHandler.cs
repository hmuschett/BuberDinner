using buberDinner.Application.Authentication.Common;
using buberDinner.Application.Common.Interfaces.Authentication;
using buberDinner.Application.Common.Interfaces.Persistence;
using buberDinner.Domain.Entities;
using ErrorOr;
using MediatR;

namespace buberDinner.Application.Authentication.Commands.Register;

 public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

   public RegisterCommandHandler(IUserRepository userRepository,
                                  IJwtTokenGenerator jwtTokenGenerator = null)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        //Check is user already exist
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Domain.Errors.Errors.User.DuplicateEmail;
        }
        //Create user (Generate unique Id) & persistence
        var user = new User{
            FirstName= command.FirstName,
            LastName= command.LastName,
            Email= command.Email,
            Password= command.Password
        };

        _userRepository.Add(user);

        //Create JWT Token        
        var token = _jwtTokenGenerator.GeneratorToken(user);

         return new AuthenticationResult(
             user,
             token);
    }
}