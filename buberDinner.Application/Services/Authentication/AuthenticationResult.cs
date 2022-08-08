using buberDinner.Domain.Entities;

namespace buberDinner.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);
