using buberDinner.Domain.Entities;

namespace buberDinner.Application.Authentication.Common;

public record AuthenticationResult(User User,
                                  string Token);