using TravelManagement.Domain.Common;

namespace TravelManagement.Domain.Entities;

public class User : Entity
{
    public string Email { get; init; }
    public string Password { get; init; }
}