using buberDinner.Domain.Entities;

namespace buberDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator{
    string GeneratorToken(User user);
}