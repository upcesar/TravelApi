using TravelManagement.Domain.Common;

namespace TravelManagement.Domain.Entities;

public class User : Entity
{
    public string Email { get; init; }
    public string FullName { get; init; }
    public string Password { get; init; }

    public User(string email, string fullName, string password)
    {
        Email = email;
        FullName = fullName;
        Password = password;
    }
}