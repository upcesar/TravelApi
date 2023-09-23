using TravelManagement.Domain.Common;
using TravelManagement.Domain.Entities;
using TravelManagement.Domain.Interfaces;
using TravelManagement.Domain.SmartEnums;

namespace TravelManagement.Infra.Services;

public class TravelService : ITravelService
{
    public IEnumerable<Weather> GetCountriesForecast()
    {
        var Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        var countries = SmartEnumerator.AsEnumerable<Countries>();

        return countries.Select(country => new Weather
        {
            Country = country,
            Forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
        });
    }
}