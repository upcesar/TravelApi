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
    //public User(Guid id, string email, string fullName, string password) : this(email, fullName, password)
    //{
    //    Id = id;
    //}

    public User(Guid id, string fullName, string email, string password, DateTimeOffset createdAt, DateTimeOffset? updatedAt)
    {
        Id = id;
        Email = email;
        FullName = fullName;
        Password = password;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    //(System.Guid Id, System.String FullName, System.String Email, System.String Password, System.DateTimeOffset CreatedAt, System.DateTimeOffset UpdatedAt)
}