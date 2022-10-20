using buberDinner.Domain.Entities;

namespace buberDinner.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);
