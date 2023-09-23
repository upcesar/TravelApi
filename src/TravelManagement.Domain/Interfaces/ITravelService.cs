using TravelManagement.Domain.Entities;

namespace TravelManagement.Domain.Interfaces;

public interface ITravelService
{
    IEnumerable<Weather> GetCountriesForecast();
}
