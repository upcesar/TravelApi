using TravelManagement.Domain.Entities;

namespace TravelManagement.Api.Responses;

public class AuthenticateResponse
{
    public string Email { get; init; }
    public string FullName { get; init; }
    public string Token { get; init; }

    public AuthenticateResponse(User user, string token)
    {
        Email = user.Email;
        FullName = user.FullName;
        Token = token;
    }
}
