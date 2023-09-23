using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelManagement.Domain.Interfaces;

namespace TravelManagement.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class TravelController : ControllerBase
{
    private readonly ILogger<TravelController> _logger;
    private readonly ITravelService _travelService;

    public TravelController(ILogger<TravelController> logger, ITravelService travelService)
    {
        _logger = logger;
        _travelService = travelService;
    }

    [AllowAnonymous]
    [HttpGet("countries/forecast", Name = nameof(GetCountriesForecast))]
    public IActionResult GetCountriesForecast()
    {
        var weather = _travelService.GetCountriesForecast();
        return Ok(weather);
    }
}
