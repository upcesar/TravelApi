using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelManagement.Api.Requests;
using TravelManagement.Api.Services;
using TravelManagement.Domain.Interfaces;
using TravelManagement.Infra.Data.Repositories;

namespace TravelManagement.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class TravelController : ControllerBase
{
    private readonly ILogger<TravelController> _logger;
    private readonly ITravelService _travelService;
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;

    public TravelController(ILogger<TravelController> logger, ITravelService travelService, IUserService userService)
    {
        _logger = logger;
        _travelService = travelService;
        _userService = userService;

    }

    [AllowAnonymous]
    [HttpGet("countries/forecast", Name = nameof(GetCountriesForecast))]
    public IActionResult GetCountriesForecast()
    {
        var weather = _travelService.GetCountriesForecast();
        return Ok(weather);
    }


    [AllowAnonymous]
    [HttpPost("user/sign-in")]
    public async Task<IActionResult> SignIn(UserRequest request)
    {
        var response = await _userService.SignIn(request);

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
        return Ok("");
    }
}
