using System.Reflection.Metadata;
using buberDinner.Application.Common.Interfaces.Persistence;
using buberDinner.Domain.Entities;

namespace buberDinner.Infrastructure.Persistence;
public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}