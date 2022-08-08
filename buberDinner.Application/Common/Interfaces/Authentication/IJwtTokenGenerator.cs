namespace buberDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator{
    string GeneratorToken(Guid userId, string  firstName, string lastName);
}