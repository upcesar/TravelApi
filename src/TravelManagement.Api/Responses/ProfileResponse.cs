using TravelManagement.Domain.Entities;

namespace TravelManagement.Api.Responses;

public class ProfileResponse
{
    public string Email { get; init; }
    public string FullName { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset? UpdatedAt { get; init; }
    public ProfileResponse(User user)
    {
        Email = user.Email;
        FullName = user.FullName;
        CreatedAt = user.CreatedAt;
        UpdatedAt = user.UpdatedAt;
    }
}