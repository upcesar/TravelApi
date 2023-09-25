namespace TravelManagement.Infra.Security.Auth;

public class JwtSettings
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Secret { get; set; }
}
