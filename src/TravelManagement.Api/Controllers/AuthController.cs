using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelManagement.Api.Requests;
using TravelManagement.Api.Services;
using TravelManagement.Infra.Data.Repositories;

namespace TravelManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<TravelController> _logger;
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;

    public AuthController(ILogger<TravelController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;

    }

    [AllowAnonymous]
    [HttpPost("user/register")]
    public async Task<IActionResult> Register(UserRequest request)
    {
        var response = await _userService.Register(request);

        if (response.IsValid)
        {
            return CreatedAtAction(nameof(GetProfile), new { fullName = request.FullName, email = request.Email });
        }

        return BadRequest(response);
    }

    [Authorize]
    [HttpGet("user/me")]
    public async Task<IActionResult> GetProfile()
    {
        return Ok(await Task.FromResult("Secret Area"));
    }
}
