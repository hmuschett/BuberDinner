using buberDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace buberDinner.Application.Authentication.Queries.Login;

public record LoginQuery(string Email,
                         string Password) : IRequest<ErrorOr<AuthenticationResult>>;
