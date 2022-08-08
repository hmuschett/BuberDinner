using buberDinner.Domain.Entities;

namespace buberDinner.Application.Common.Interfaces.Persistence;
public interface IUserRepository{
    User? GetUserByEmail(string email);
    void Add(User user);
}