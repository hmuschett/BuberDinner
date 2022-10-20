using buberDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace buberDinner.Application.Authentication.Commands.Register;

public record RegisterCommand(string FirstName,
                              string LastName,
                              string Email,
                              string Password) : IRequest<ErrorOr<AuthenticationResult>>;
