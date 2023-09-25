using Microsoft.AspNetCore.Http;
using TravelManagement.Infra.Data.Repositories;

namespace TravelManagement.Infra.Security.Auth;
public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserRepository userRepository, IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userId = jwtUtils.ValidateJwtToken(token);
        if (userId != null)
        {
            // attach user to context on successful jwt validation
            context.Items["User"] = await userRepository.GetByIdAsync(userId.Value);
        }

        await _next(context);
    }
}
