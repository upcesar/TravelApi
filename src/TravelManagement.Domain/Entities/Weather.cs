using TravelManagement.Domain.Common;
using TravelManagement.Domain.SmartEnums;

namespace TravelManagement.Domain.Entities;

public class Weather : Entity
{
    public Countries Country { get; init; }

    public IEnumerable<WeatherForecast> Forecasts { get; init; }
}
